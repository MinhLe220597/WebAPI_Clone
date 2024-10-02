using DataContext.Entities;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.BaseModel;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class CustomerServices : ICustomerServices
    {
        private LearningDBContext _context;

        public CustomerServices(LearningDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddOrUpdateCustomer(CustomerModel model)
        {
            //message = string.Empty;
            var customer = new Customer()
            {
                Id = model.Id ?? Guid.Empty,
                FullName = model.FullName ?? string.Empty,
                Birthday = model.Birthday,
                Email = model.Email,
            };

            //if (string.IsNullOrEmpty(model.FullName))
            //    message = "Khách hàng không được phép trống!";

            //if (model.Birthday == null)
            //    message = "Ngày sinh không được phép trống!";

            //if (model.Email == null)
            //    message = "Email không được phép trống!";

            //if (!string.IsNullOrEmpty(message))
            //    return customer;

            await _context._customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public int DeleteCustomer(BaseHandleProcessModel model)
        {
            var listCustomer = _context._customers.Where(s => model.RecordIds != null && model.RecordIds.Contains(s.Id)).ToList();
            listCustomer.ForEach(item => item.IsDelete = true);
            return _context.SaveChanges();
        }
    }
}

