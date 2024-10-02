using System;
using CoreService.DataContext.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreService.DataContext
{
	public class ApiDbContext: IdentityDbContext
    {
		public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
		{
		}

        public DbSet<UserInfo> _userInfos { get; set; }

    }
}

