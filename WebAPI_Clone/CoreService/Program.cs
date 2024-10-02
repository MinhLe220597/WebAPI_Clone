using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text;
using CoreService.Configurations;
using CoreService.DataContext;
using CoreService.Middlewares;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key:"JwtConfig"));
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//handle authentication
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApiDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JwtConfig:Secret").Value);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = false
    };
});

builder.Services.AddCors(options => options.AddPolicy("FrontEnd", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

#region Example Cookie
//builder.Services.AddDataProtection();
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<AuthService>();
//builder.Services.AddAuthentication("cookie")
//    .AddCookie("cookie");
#endregion

var app = builder.Build();
app.UseAuthentication();

#region Example Cookie
//app.Use((ctx, next) =>
//{
//    var idp = ctx.RequestServices.GetRequiredService<IDataProtectionProvider>();
//    var protector = idp.CreateProtector("auth-cookie");

//    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(s => s.StartsWith("auth="));
//    var protectedPayload = authCookie.Split("=").Last();
//    var payload = protector.Unprotect(protectedPayload);
//    var parts = payload.Split(":");
//    var key = parts[0];
//    var value = parts[1];

//    var claims = new List<Claim>();
//    claims.Add(new Claim(key, value));
//    var identity = new ClaimsIdentity(claims);
//    ctx.User = new ClaimsPrincipal(identity);

//    return next();
//});

//app.MapGet("/username", (HttpContext ctx) =>
//{
//    return ctx.User.FindFirst("usr")?.Value;
//});

//app.MapGet("/login", async (HttpContext ctx) =>
//{
//    //auth.SignIn();

//    var claims = new List<Claim>();
//    claims.Add(new Claim("usr", "minhle"));
//    var identity = new ClaimsIdentity(claims, "cookie");
//    var user = new ClaimsPrincipal(identity);

//    await ctx.SignInAsync("cookie", user);
//    return "oke";
//});

//public class AuthService
//{
//    private readonly IDataProtectionProvider _idp;
//    private readonly IHttpContextAccessor _accessor;

//    public AuthService(IDataProtectionProvider idp, IHttpContextAccessor accessor)
//    {
//        _idp = idp;
//        _accessor = accessor;
//    }

//    public void SignIn()
//    {
//        var protector = _idp.CreateProtector("auth-cookie");
//        _accessor.HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:minh.le")}";
//    }
//}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("FrontEnd");
app.MapControllers();

app.UseMiddleware<SimpleMiddleware>();
app.Run();
