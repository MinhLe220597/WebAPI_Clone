using System;
using DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.BaseModel;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class ProductServices : IProductServices
    {
        private LearningDBContext _context;

        public ProductServices(LearningDBContext context)
        {
            _context = context;
        }

        public async Task<Product> AddOrUpdateProduct(ProductModel model)
        {
            //message = string.Empty;
            var product = new Product()
            {
                Id = model.Id ?? Guid.Empty,
                Name = model.Name ?? string.Empty,
                Price = model.Price,
                ShopId = model.ShopId,
            };

            //if (string.IsNullOrEmpty(model.Name))
            //    message = "Tên sản phẩm không được phép trống!";

            //if (model.Price == null)
            //    message = "Đơn giá không được phép trống!";

            //if (!string.IsNullOrEmpty(message))
            //    return product;

            await _context._products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public int DeleteProduct(BaseHandleProcessModel model)
        {
            var listProduct = _context._products.Where(s => model.RecordIds != null && model.RecordIds.Contains(s.Id)).ToList();
            listProduct.ForEach(item =>
            {
                item.IsDelete = true;
                _context.Entry(item).State = EntityState.Modified;
            });
            return _context.SaveChanges();
        }
    }
}

