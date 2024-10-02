using DataContext.Entities;
using Library.Core;
using Library.Core.BaseModel;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business.Infrastructure;
using WebAPI.Core.Infrastructute;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class CategoryServices : ICategoryServices
    {
        private LearningDBContext _context;
        private IResponsitory _reponsitory;

        public CategoryServices(LearningDBContext context, IResponsitory responsitory)
        {
            _context = context;
            _reponsitory = responsitory;
        }

        public async Task<CategoryReponse> AddOrUpdateCategory(CategoryModel model)
        {
            var result = new CategoryReponse();
            var category = new Category()
            {
                Id = model.Id ?? Guid.Empty,
                Code = model.Code ?? string.Empty,
                CategoryName = model.CategoryName ?? string.Empty,
                Note = model.Note,
            };
            result.Category = category;

            if (string.IsNullOrEmpty(model.Code))
                result.Message = "Mã danh mục không được phép trống!";

            if (string.IsNullOrEmpty(model.CategoryName))
                result.Message = "Tên danh mục không được phép trống!";

            if (!string.IsNullOrEmpty(result.Message))
                return result;

            var savedMessage = await _reponsitory.AddOrEditEntity(category);
            result.Message = savedMessage.ToString();
            return result;
        }

        public async Task<int> DeleteCategory(BaseHandleProcessModel model)
        {
            var listCategory = await _context._categories.Where(s => model.RecordIds != null
                    && model.RecordIds.Contains(s.Id))
                .ToListAsync();

            listCategory.ForEach(item => item.IsDelete = true);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories(CategorySearchModel model)
        {
            var categories = await _context._categories.AsNoTracking()
                .Where(s => s.IsDelete != true)
                .OrderByDescending(s => s.DateUpdate)
                .ToListAsync();

            return categories;
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await _context._categories.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

