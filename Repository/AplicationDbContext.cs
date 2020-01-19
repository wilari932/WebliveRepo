using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Custumer>().HasMany(x => x.Orders)
               .WithOne(x => x.Custumer)
               .OnDelete(DeleteBehavior.Cascade);

           


            modelBuilder.Entity<ProductOrder>()
       .HasKey(bc => new { bc.ProductId, bc.OrderId });
            modelBuilder.Entity<ProductOrder>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductOrders)
                .HasForeignKey(bc => bc.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(bc => bc.Order)
                .WithMany(c => c.ProductOrders)
                .HasForeignKey(bc => bc.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
