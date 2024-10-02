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
    [Route("api/Order")]
    public class OrderController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly IOrderServices _orderServices;
        private readonly ICategoryServices _categoryServices;

        public OrderController(LearningDBContext context, ICategoryServices categoryServices)
        {
            _context = context;
            _categoryServices = categoryServices;
            _orderServices = new OrderServices(_context, _categoryServices);
        }

        /// <summary>
        /// GetListOrder
        /// </summary>
        /// <returns>List Order</returns>
        [HttpPost("/api/Order/GetListOrder")]
        public async Task<IApiResultGrid<OrderModel>> GetListOrder(OrderSearchModel model)
        {
            var orders = await _orderServices.GetOrders(model);
            return ResultGrid(orders, model.Skip, model.Take);
        }

        /// <summary>
        /// GetOrderByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Order</returns>
        [HttpGet("/api/Order/GetOrderByID/{id}")]
        public async Task<IApiResult<Order?>> GetOrderByID(Guid id)
        {
            var order = await _context._orders.FirstOrDefaultAsync(s => s.Id == id);
            return Result(order);
        }

        /// <summary>
        /// AddOrUpdateOrder
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Order</returns>
        [HttpPost("/api/Order/AddOrUpdateOrder")]
        public async Task<IApiResult<Order>> AddOrUpdateOrder(OrderModel model)
        {
            try
            {
                var result = await _orderServices.AddOrUpdateOrder(model);
                //return Result(result, message, string.IsNullOrEmpty(message) ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
                return Result(result);
            }
            catch (Exception ex)
            {
                return Result(new Order(), ex.Message, ResponseCode.E_ERROR);
            }
        }

        /// <summary>
        /// DeleteOrder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Order/DeleteOrder")]
        public IApiResult<int> DeleteOrder(BaseHandleProcessModel model)
        {
            var message = _orderServices.DeleteOrder(model);
            return Result(message, message.ToString(), message > 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        }

        /// <summary>
        /// CheckTotalCustomer
        /// </summary>
        /// <returns>boolean</returns>
        [HttpGet("/api/Order/CheckTotalAllData")]
        public async Task<IApiResult<bool>> CheckTotalAllData()
        {

            var countShop = await _context._shops
                .Where(s => s.IsDelete != true)
                .CountAsync();

            var countProduct = await _context._products
                .Where(s => s.IsDelete != true)
                .CountAsync();

            var countCustomer = await _context._customers
                .Where(s => s.IsDelete != true)
                .CountAsync();

            var result = false;
            if (countCustomer >= 30 && countShop >= 3 && countProduct >= 3000)
                result = true;

            return Result(result);
        }
    }
}

