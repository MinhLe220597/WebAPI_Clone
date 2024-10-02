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
    [Route("api/Shop")]
    public class ShopController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly IShopServices _shopServices;

        public ShopController(LearningDBContext context)
        {
            _context = context;
            _shopServices = new ShopServices(_context);
        }

        /// <summary>
        /// GetListShop
        /// </summary>
        /// <returns>List Shop</returns>
        [HttpPost("/api/Shop/GetListShop")]
        public async Task<IApiResultGrid<Shop>> GetListShop(ShopSearchModel model)
        {
            var listShop = await _context._shops
                .Where(s => s.IsDelete != true)
                .OrderByDescending(s => s.Location)
                .ToListAsync();

            return ResultGrid(listShop, model.Skip, model.Take);
        }


        /// <summary>
        /// GetListShopMulti
        /// </summary>
        /// <returns>List Shop</returns>
        [HttpGet("/api/Shop/GetListShopMulti")]
        public async Task<IApiResult<List<Shop>>> GetListShopMulti()
        {
            var listShop = await _context._shops
                .Where(s => s.IsDelete != true)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return Result(listShop);
        }

        /// <summary>
        /// GetShopByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Shop</returns>
        [HttpGet("/api/Shop/GetShopByID/{id}")]
        public async Task<IApiResult<Shop?>> GetShopByID(Guid id)
        {
            var shop = await _context._shops.FirstOrDefaultAsync(s => s.Id == id);
            return Result(shop);
        }

        /// <summary>
        /// AddOrUpdateShop
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Shop</returns>
        [HttpPost("/api/Shop/AddOrUpdateShop")]
        public async Task<IApiResult<Shop>> AddOrUpdateShop(ShopModel model)
        {
            var result = await _shopServices.AddOrUpdateShop(model);
            //return Result(result, message, string.IsNullOrEmpty(message) ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
            return Result(result);
        }

        /// <summary>
        /// DeleteShop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Shop/DeleteShop")]
        public IApiResult<int> DeleteShop(BaseHandleProcessModel model)
        {
            var message = _shopServices.DeleteShop(model);
            return Result(message, message.ToString(), message > 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        }

        /// <summary>
        /// CheckTotalShop
        /// </summary>
        /// <returns>boolean</returns>
        [HttpGet("/api/Shop/CheckTotalShop")]
        public async Task<IApiResult<bool>> CheckTotalShop()
        {
            var countShop = await _context._shops
                .Where(s => s.IsDelete != true)
                .CountAsync();

            return Result(countShop >= 3 ? true : false);
        }
    }
}

