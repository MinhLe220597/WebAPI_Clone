using System;
using DataContext.Entities;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.BaseModel;
using Library.Core.Source;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class ShopServices : IShopServices
    {
        private LearningDBContext _context;

        public ShopServices(LearningDBContext context)
        {
            _context = context;
        }

        public async Task<Shop> AddOrUpdateShop(ShopModel model)
        {
            //message = string.Empty;
            var shop = new Shop()
            {
                Id = model.Id ?? Guid.Empty,
                Name = model.Name ?? string.Empty,
                Location = model.Location ?? string.Empty,
            };

            //if (string.IsNullOrEmpty(model.Name))
            //    message = "Tên cửa hàng không được phép trống!";

            //if (string.IsNullOrEmpty(model.Location))
            //    message = "Địa chỉ không được phép trống!";

            //if (!string.IsNullOrEmpty(message))
            //    return shop;

            await _context._shops.AddAsync(shop);
            await _context.SaveChangesAsync();
            return shop;
        }

        public int DeleteShop(BaseHandleProcessModel model)
        {
            var listShop = _context._shops.Where(s => model.RecordIds != null && model.RecordIds.Contains(s.Id)).ToList();
            listShop.ForEach(item => item.IsDelete = true);
            return _context.SaveChanges();
        }
    }
}

