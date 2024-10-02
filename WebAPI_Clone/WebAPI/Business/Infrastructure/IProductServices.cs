using System;
using DataContext.Entities;
using Library.Core.BaseModel;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface IProductServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<Product> AddOrUpdateProduct(ProductModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int DeleteProduct(BaseHandleProcessModel model);
    }
}

