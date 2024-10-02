using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Order")]
	public class Order
	{
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ShopId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ProductId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(50)]
		public string? UserCreate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime DateCreate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(50)]
		public string? UserUpdate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime DateUpdate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public bool? IsDelete { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual Shop Shop { get; set; }
		public virtual Product Product { get; set; }
    }
}

