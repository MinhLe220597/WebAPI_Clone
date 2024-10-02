using System;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class OrderModel
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }

        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? ShopName { get; set; }
        public string? Location { get; set; }
        public string? ProductName { get; set; }
    }

    public class OrderSearchModel: RequestGrid
    {
        public List<Guid>? ListProductId { get; set; }
    }

}

