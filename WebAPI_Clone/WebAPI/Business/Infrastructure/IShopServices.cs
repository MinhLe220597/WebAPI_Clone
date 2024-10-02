
using System;
using DataContext.Entities;
using Library.Core.BaseModel;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface IShopServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<Shop> AddOrUpdateShop(ShopModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteShop(BaseHandleProcessModel model);
    }
}

