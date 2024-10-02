using System;
using DataContext.Entities;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.BaseModel;
using WebAPI.DataContext;
using WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Business
{
    public class OrderServices : IOrderServices
    {
        private LearningDBContext _context;
        private ICategoryServices _categoryService;

        public OrderServices(LearningDBContext context, ICategoryServices categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public async Task<Order> AddOrUpdateOrder(OrderModel model)
        {
            var order = new Order()
            {
                Id = model.Id ?? Guid.Empty,
                CustomerId = model.CustomerId,
                ShopId = model.ShopId,
                ProductId = model.ProductId,
            };

            await _context._orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public int DeleteOrder(BaseHandleProcessModel model)
        {
            var listOrder = _context._orders.Where(s => model.RecordIds != null && model.RecordIds.Contains(s.Id)).ToList();
            listOrder.ForEach(item => item.IsDelete = true);
            return _context.SaveChanges();
        }

        public async Task<List<OrderModel>> GetOrders(OrderSearchModel model)
        {
            var orders = await _context._orders.AsNoTracking()
                .Where(s => s.IsDelete != true)
                .Include(order => order.Customer)
                .Include(order => order.Shop)
                .Include(order => order.Product)
                .Select(s => new OrderModel()
                {
                    Id = s.Id,
                    CustomerId = s.Customer.Id,
                    CustomerName = s.Customer.FullName,
                    Email = s.Customer.Email,
                    ShopId = s.Shop.Id,
                    ShopName = s.Shop.Name,
                    Location = s.Shop.Location,
                    ProductId = s.Product.Id,
                    ProductName = s.Product.Name
                })
                .Where(s => model.ListProductId == null || model.ListProductId.Contains(s.ProductId))
                .OrderBy(s => s.Email)
                .ThenByDescending(s => s.Location)
                .ThenBy(s => s.ProductName)
                .ToListAsync();

            return orders;
        }
    }
}

