using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop_DotNetCore.Models;
using System.Drawing;

namespace Shop_DotNetCore.Data
{
    public class MyEshopContext : DbContext
    {

        public MyEshopContext(DbContextOptions<MyEshopContext> Options) : base(Options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });


            modelBuilder.Entity<Item>(c =>
            {
                c.Property(w => w.Price).HasColumnType("Money");
                c.HasKey(w => w.ID);
            });





            #region Category Seed Data

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Book",
                Description = "Mathematics and physics",

            }
            , new Category()
            {
                Id = 2,
                Name = "Car",
                Description = "Effordable and fast"
            }
            , new Category()
            {
                Id = 3,
                Name = "Laptop",
                Description = "The new generation of laptops"
            }
            , new Category()
            {
                Id = 4,
                Name = "Tablet",
                Description = "Samsung"
            },
            new Category()
            {
                Id = 5,
                Name = "Movies",
                Description = "Science-finction movies"
            }
            );


            modelBuilder.Entity<Item>().HasData(
                new Item { ID = 1, Price = 20, QuantityInStock = 440 },
                new Item { ID = 2, Price = 30, QuantityInStock = 30 },
                new Item { ID = 3, Price = 40, QuantityInStock = 34 },
                new Item { ID = 4, Price = 20, QuantityInStock = 33 }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ItemID = 1, Name = "Wormhole1" , Description = "Closest to Milky way" },
                new Product { Id = 2, ItemID = 2, Name = "Wormhole2" , Description = "The first wormhole ever discovered" },
                new Product { Id = 3, ItemID = 3, Name = "Wormhole3" , Description = "The farthest known wormhole " }
                );

            modelBuilder.Entity<CategoryToProduct>().HasData(
                
                new CategoryToProduct { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct { CategoryId = 4, ProductId = 3 },
                new CategoryToProduct { CategoryId = 5, ProductId = 3 }

            );




            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }



}
