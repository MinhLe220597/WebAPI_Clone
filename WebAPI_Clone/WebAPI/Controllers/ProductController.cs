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
    [Route("api/Product")]
    public class ProductController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly IProductServices _productServices;

        public ProductController(LearningDBContext context)
        {
            _context = context;
            _productServices = new ProductServices(_context);
        }

        /// <summary>
        /// GetListProduct
        /// </summary>
        /// <returns>List Product</returns>
        [HttpPost("/api/Product/GetListProduct")]
        public async Task<IApiResultGrid<ProductModel>> GetListProduct(ProductSearchModel model)
        {
            var listProduct = await (from product in _context._products
                                     where product.IsDelete != true
                                     join shop in _context._shops on product.ShopId equals shop.Id into Shops
                                     from sh in Shops.DefaultIfEmpty()
                                     select new ProductModel()
                                     {
                                         Id = product.Id,
                                         Name = product.Name,
                                         Price = product.Price,
                                         ShopId = product.ShopId,
                                         ShopName = sh.Name,
                                     })
                                   .Where(s => string.IsNullOrEmpty(model.Name) || s.Name.Contains(model.Name))
                                   .OrderBy(s => s.Name)
                                   .ToListAsync();

            return ResultGrid(listProduct, model.Skip, model.Take);
        }

        /// <summary>
        /// GetListProductMulti
        /// </summary>
        /// <returns>List Product</returns>
        [HttpGet("/api/Product/GetListProductMulti/{shopID}")]
        public async Task<IApiResult<List<Product>>> GetListProductMulti(Guid shopID)
        {
            var listProduct = await _context._products
                .Where(s => s.IsDelete != true && s.ShopId == shopID)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return Result(listProduct);
        }

        /// <summary>
        /// GetListProductAll
        /// </summary>
        /// <returns>List Product</returns>
        [HttpGet("/api/Product/GetListProductAll")]
        public async Task<IApiResult<List<Product>>> GetListProductAll()
        {
            var listProduct = await _context._products
                .Where(s => s.IsDelete != true)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return Result(listProduct);
        }

        /// <summary>
        /// GetProductByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Product</returns>
        [HttpGet("/api/Product/GetProductByID/{id}")]
        public async Task<IApiResult<Product?>> GetProductByID(Guid id)
        {
            var product = await _context._products.FirstOrDefaultAsync(s => s.Id == id);
            return Result(product);
        }

        /// <summary>
        /// AddOrUpdateProduct
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Product</returns>
        [HttpPost("/api/Product/AddOrUpdateProduct")]
        public async Task<IApiResult<Product>> AddOrUpdateProduct(ProductModel model)
        {
            var result = await _productServices.AddOrUpdateProduct(model);
            //return Result(result, message, string.IsNullOrEmpty(message) ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
            return Result(result);
        }

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Product/DeleteProduct")]
        public IApiResult<int> DeleteProduct(BaseHandleProcessModel model)
        {
            var message = _productServices.DeleteProduct(model);
            return Result(message, message.ToString(), message > 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        }

        /// <summary>
        /// checkCountProduct
        /// </summary>
        /// <returns>boolean</returns>
        [HttpGet("/api/Product/CheckTotalProduct")]
        public async Task<IApiResult<bool>> CheckTotalProduct()
        {
            var countProduct = await _context._products
                .Where(s => s.IsDelete != true)
                .CountAsync();

            return Result(countProduct >= 3000 ? true : false);
    }
}
}

