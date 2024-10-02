using System;
using DataContext.Entities;
using Library.Core.BaseModel;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface IOrderServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<Order> AddOrUpdateOrder(OrderModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteOrder(BaseHandleProcessModel model);

        Task<List<OrderModel>> GetOrders(OrderSearchModel model);
    }
}

