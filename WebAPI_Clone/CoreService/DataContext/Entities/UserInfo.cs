using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreService.DataContext.Entities
{
    [Table("UserInfo")]
    public class UserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? ProfileID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? UserCreate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateCreate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? UserUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IsDelete { get; set; }
    }
}

