using System;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class ProductModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Guid ShopId { get; set; }
        public string? ShopName { get; set; }
    }

    public class ProductSearchModel : RequestGrid
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
    }

}

