using System;
using Library.Core.BaseModel;

namespace WebAPI.Model
{
    public class CustomerModel
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }
    }

    public class CustomerSearchModel: RequestGrid
    {
        public string? Name { get; set; }
    }

}

