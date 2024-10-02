using System;
using DataContext.Entities;
using Library.Core.BaseModel;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface ICustomerServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<Customer> AddOrUpdateCustomer(CustomerModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteCustomer(BaseHandleProcessModel model);
    }
}

