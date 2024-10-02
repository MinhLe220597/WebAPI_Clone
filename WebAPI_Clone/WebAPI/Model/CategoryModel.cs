using System;
using System.ComponentModel.DataAnnotations;
using DataContext.Entities;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class CategoryModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Category Code is required!")]
        [StringLength(50, ErrorMessage = "Category Code cannot exceed 50 characters!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Category Name is required!")]
        [StringLength(250, ErrorMessage = "Category Name cannot exceed 250 characters!")]
        public string CategoryName { get; set; }

        public string? Note { get; set; }
    }

    public class CategorySearchModel: RequestGrid
    {
        public string? Code { get; set; }
        public string? CategoryName { get; set; }
    }

    public class CategoryReponse: ResponseModel
    {
        public Category Category { get; set; } = new Category();
    }
}

