using AlphaLife.WebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaLife.WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product_Category>().HasKey(am => new {am.ProductId, am.CategoryId});
            builder.Entity<Product_Category>().HasOne(m => m.Product).WithMany(am => am.Product_Categories).HasForeignKey(m => m.ProductId);
            builder.Entity<Product_Category>().HasOne(m => m.Category).WithMany(am => am.Product_Categories).HasForeignKey(m => m.CategoryId);
            base.OnModelCreating(builder);
        }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product_Category> Products_Categories { get; set; }
    }
}
