using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreService.Configurations;
using CoreService.DataContext;
using CoreService.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Library.Core;
using BC = BCrypt.Net.BCrypt;
using Library.Core.Interface;
using Library.Core.Source;

namespace CoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthManagementController : CoreServices
    {
        private readonly ILogger<AuthManagementController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApiDbContext _context;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementController(ILogger<AuthManagementController> logger,
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            ApiDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto userRegistrationRequestDto)
        {
            if (ModelState.IsValid)
            {
                //check if email exist
                var emailExist = await _userManager.FindByEmailAsync(userRegistrationRequestDto.Email);
                if (emailExist != null)
                    return BadRequest("Email already exist");

                var newUser = new IdentityUser()
                {
                    Email = userRegistrationRequestDto.Email,
                    UserName = userRegistrationRequestDto.Email
                };

                var isCreated = await _userManager.CreateAsync(newUser, userRegistrationRequestDto.Password);
                if (isCreated.Succeeded)
                {
                    //generate token
                    var token = GenerateJwtToken(newUser);

                    return Ok(new RegistrationRequestResponse()
                    {
                        Result = true,
                        Token = token
                    });
                }

                return BadRequest(isCreated.Errors.Select(s => s.Description).ToList());
            }

            return BadRequest("Invalid request payload");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IApiResult<LoginRequestResponse>> Login([FromBody] UserLoginRequestDto userLogin)
        {
            var result = new LoginRequestResponse();
            if (ModelState.IsValid)
            {
                // Generate a salt for bcrypt encryption
                string salt = BC.GenerateSalt();

                // Hash the password with bcrypt
                string hashPassword = BC.HashPassword(userLogin.Password, salt);

                //check if email exist
                var existingUser = await _userManager.FindByEmailAsync(userLogin.Email);
                if (existingUser == null)
                {
                    //check if user exist
                    var userInfo = await _context._userInfos.FirstOrDefaultAsync(s => s.Email == userLogin.Email);
                    if (userInfo == null || !BC.Verify(userLogin.Password, hashPassword))
                        return Result(result, "Invalid authentication", ResponseCode.E_FAIL);

                    //userRegistrationRequestDto.Password = hashPassword;
                    if (await RegisterUser(userLogin))
                        existingUser = await _userManager.FindByEmailAsync(userLogin.Email);
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, userLogin.Password);
                if (isPasswordValid)
                {
                    result.Token = GenerateJwtToken(existingUser);
                    result.UserLogin = existingUser.Email;
                    return Result(result);
                }

                return Result(result, "Invalid authentication", ResponseCode.E_FAIL);
            }

            return Result(result, "Invalid request payload", ResponseCode.E_FAIL);
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromBody] UserLoginRequestDto userLogin)
        {
            if (ModelState.IsValid)
            {
                //check if email exist
                var existingUser = await _userManager.FindByEmailAsync(userLogin.Email);
                if (existingUser != null)
                {
                    var isDeleted = await _userManager.DeleteAsync(existingUser);
                    if (isDeleted.Succeeded)
                    {
                        return Ok(new RegistrationRequestResponse()
                        {
                            Result = true
                        });
                    }
                }
                return BadRequest("User doesn't exist");
            }

            return BadRequest("Invalid request payload");
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }

        private async Task<bool> RegisterUser(UserLoginRequestDto userLogin)
        {
            var newUser = new IdentityUser()
            {
                Email = userLogin.Email,
                UserName = userLogin.Email
            };

            var isCreated = await _userManager.CreateAsync(newUser, userLogin.Password);
            return isCreated.Succeeded;
        }
    }
}

