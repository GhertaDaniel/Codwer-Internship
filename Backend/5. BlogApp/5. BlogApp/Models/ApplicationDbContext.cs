using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _5._BlogApp.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{

		public ApplicationDbContext(DbContextOptions options) : base(options) { }

		public virtual DbSet<Blog> Blogs { get; set; }
		public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

