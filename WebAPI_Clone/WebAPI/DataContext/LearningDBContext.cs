using System;
using Microsoft.EntityFrameworkCore;
using DataContext.Entities;

namespace WebAPI.DataContext
{
	public class LearningDBContext: DbContext
	{
		public LearningDBContext(DbContextOptions<LearningDBContext> context): base(context)
		{
		}

		public DbSet<Category> _categories { get; set; }
		public DbSet<Shop> _shops { get; set; }
		public DbSet<Product> _products { get; set; }
		public DbSet<Customer> _customers { get; set; }
		public DbSet<Order> _orders { get; set; }
    } 
}

