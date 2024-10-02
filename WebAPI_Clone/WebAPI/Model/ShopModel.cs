using System;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class ShopModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
    }

    public class ShopSearchModel: RequestGrid
    {
        public string? Code { get; set; }
        public string? CategoryName { get; set; }
    }
}

