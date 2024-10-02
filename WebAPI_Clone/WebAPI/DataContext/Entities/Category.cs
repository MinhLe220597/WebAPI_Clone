using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Table("Category")]
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(50)]
		public string? Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(250)]
		public string? CategoryName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MaxLength(500)]
		public string? Note { get; set; }

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
	}
}

