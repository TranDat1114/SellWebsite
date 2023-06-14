using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SellWebsite.Models.Models;

namespace SellWebsite.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Product>()
           .HasMany(p => p.Categories)
           .WithMany(c => c.Products)
           .UsingEntity(j => j.ToTable("CategoryProduct"));

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .Property(e => e.UpdatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
              .Property(e => e.Price)
              .HasDefaultValueSql("0");

            modelBuilder.Entity<Product>()
               .Property(e => e.Credits)
               .HasDefaultValueSql("'JADY'");

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .HasDefaultValueSql("'/assets/dev.png'");

            modelBuilder.Entity<ShoppingCart>()
               .Property(e => e.Quantity)
               .HasDefaultValueSql("1");

            base.OnModelCreating(modelBuilder);

        }
    }
}
