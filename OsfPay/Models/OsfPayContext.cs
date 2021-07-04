using Microsoft.EntityFrameworkCore;
using OsfPay.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsfPay.Models
{
    public class OsfPayContext : DbContext
    {
        public OsfPayContext(DbContextOptions<OsfPayContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Apple Pie",
                    ShortDescription = "Lorem Ipsum",
                    Price = 14.25M,
                    ImageUrl = "ApplePie.jpg"

                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 2,
                    Name = "Cheese Cake",
                    ShortDescription = "Lorem Ipsum",
                    Price = 16.75M,
                    ImageUrl = "CheeseCake.jpg"

                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 3,
                    Name = "Chocolate Cake",
                    ShortDescription = "Lorem Ipsum",
                    Price = 12.45M,
                    ImageUrl = "ChocolateCake.jpg"
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 4,
                    Name = "Pumpkin Pie",
                    ShortDescription = "Lorem Ipsum",
                    Price = 13.25M,
                    ImageUrl = "PumkinPie.jpg"
                });
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   ProductId = 5,
                   Name = "Strawberry Pie",
                   ShortDescription = "Lorem Ipsum",
                   Price = 15.75M,
                   ImageUrl = "StrawberryPie.jpg"
               });

        }
    }
}
