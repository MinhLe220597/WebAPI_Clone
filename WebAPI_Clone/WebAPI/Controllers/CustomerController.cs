using DataContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.BaseModel;
using Library.Core.Interface;
using Library.Core.Source;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly ICustomerServices _customerServices;

        public CustomerController(LearningDBContext context)
        {
            _context = context;
            _customerServices = new CustomerServices(_context);
        }

        /// <summary>
        /// GetListCustomer
        /// </summary>
        /// <returns>List Customer</returns>
        [HttpPost("/api/Customer/GetListCustomer")]
        public async Task<IApiResultGrid<Customer>> GetListCustomer(CustomerSearchModel model)
        {
            var listCustomer = await _context._customers
                .Where(s => s.IsDelete != true)
                .OrderBy(s => s.Email)
                .ToListAsync();

            return ResultGrid(listCustomer, model.Skip, model.Take);
        }

        /// <summary>
        /// GetListCustomerMulti
        /// </summary>
        /// <returns>List Customer</returns>
        [HttpGet("/api/Customer/GetListCustomerMulti")]
        public async Task<IApiResult<List<Customer>>> GetListCustomerMulti()
        {
            var listCustomer = await _context._customers
                .Where(s => s.IsDelete != true)
                .OrderBy(s => s.FullName)
                .ToListAsync();

            return Result(listCustomer);
        }

        /// <summary>
        /// GetCustomerByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Customer</returns>
        [HttpGet("/api/Customer/GetCustomerByID/{id}")]
        public async Task<IApiResult<Customer?>> GetCustomerByID(Guid id)
        {
            var Customer = await _context._customers.FirstOrDefaultAsync(s => s.Id == id);
            return Result(Customer);
        }

        /// <summary>
        /// AddOrUpdateCustomer
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Customer</returns>
        [HttpPost("/api/Customer/AddOrUpdateCustomer")]
        public async Task<IApiResult<Customer>> AddOrUpdateCustomer(CustomerModel model)
        {
            var result = await _customerServices.AddOrUpdateCustomer(model);
            //return Result(result, message, string.IsNullOrEmpty(message) ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
            return Result(result);
        }

        /// <summary>
        /// DeleteCustomer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Customer/DeleteCustomer")]
        public IApiResult<int> DeleteCustomer(BaseHandleProcessModel model)
        {
            var message = _customerServices.DeleteCustomer(model);
            return Result(message, message.ToString(), message > 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        }

        /// <summary>
        /// CheckTotalCustomer
        /// </summary>
        /// <returns>boolean</returns>
        [HttpGet("/api/Customer/CheckTotalCustomer")]
        public async Task<IApiResult<bool>> CheckTotalCustomer()
        {
            var countShop = await _context._customers
                .Where(s => s.IsDelete != true)
                .CountAsync();

            return Result(countShop >= 30 ? true : false);
        }
    }
}

