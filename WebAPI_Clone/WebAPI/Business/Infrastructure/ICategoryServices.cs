using System;
using DataContext.Entities;
using Library.Core.BaseModel;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface ICategoryServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<CategoryReponse> AddOrUpdateCategory(CategoryModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> DeleteCategory(BaseHandleProcessModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategories(CategorySearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category?> GetCategoryById(Guid id);
    }
}

