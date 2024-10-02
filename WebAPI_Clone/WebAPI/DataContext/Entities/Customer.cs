using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Customer")]
	public class Customer
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
		[MaxLength(250)]
		public string? FullName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthday { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(50)]
		public string? Email { get; set; }

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

		public virtual List<Order> Orders { get; set; }
	}
}

