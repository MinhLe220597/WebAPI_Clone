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
using WebAPI.Core.Infrastructute;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly ICategoryServices _categoryServices;
        private readonly IResponsitory _responsitory;

        public CategoryController(LearningDBContext context, IResponsitory responsitory)
        {
            _context = context;
            _responsitory = responsitory;
            _categoryServices = new CategoryServices(_context, _responsitory);
        }

        /// <summary>
        /// GetListCategoy
        /// </summary>
        /// <returns>List Category</returns>
        [HttpPost("/api/Category/GetListCategory")]
        public async Task<IApiResultGrid<Category>> GetListCategory(CategorySearchModel model)
        {
            var categories = await _categoryServices.GetCategories(model);
            return ResultGrid(categories, model.Skip, model.Take);
        }

        /// <summary>
        /// GetCategoryByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Category</returns>
        [HttpGet("/api/Category/GetCategoryByID/{id}")]
        public async Task<IApiResult<Category?>> GetCategoryByID(Guid id)
        {
            var category = await _categoryServices.GetCategoryById(id);
            return Result(category);
        }

        /// <summary>
        /// AddOrUpdateCategory
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Category</returns>
        [HttpPost("/api/Category/AddOrUpdateCategory")]
        public async Task<IApiResult<Category>> AddOrUpdateCategory(CategoryModel model)
        {
            try
            {
                var result = await _categoryServices.AddOrUpdateCategory(model);
                return Result(result.Category, result.Message
                    , result.Message == $"{(int)SavedCodeEnum.E_SUCCESS}"
                    ? ResponseCode.E_SUCCESS
                    : ResponseCode.E_FAIL);
            }
            catch (Exception ex)
            {
                return Result(new Category(), ex.InnerException?.Message ?? ex.Message, ResponseCode.E_FAIL);
            }
        }

        /// <summary>
        /// DeleteCategory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Category/DeleteCategory")]
        public async Task<IApiResult<int>> DeleteCategory(BaseHandleProcessModel model)
        {
            try
            {
                var message = await _categoryServices.DeleteCategory(model);
                return Result(message, message.ToString(), message != 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
            }
            catch (Exception ex)
            {
                return Result(0, ex.InnerException?.Message ?? ex.Message, ResponseCode.E_ERROR);
            }
        }
    }
}

