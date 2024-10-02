using System;
namespace CoreService.Models.DTOs
{
    public class LoginRequestResponse : AuthResult
    {
        public Guid ID { get; set; }
        public Guid ProfileID { get; set; }
        public string UserLogin { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ProfileName { get; set; } = string.Empty;
        public string Permission { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string OrgStructureName { get; set; } = string.Empty;
    }
}

