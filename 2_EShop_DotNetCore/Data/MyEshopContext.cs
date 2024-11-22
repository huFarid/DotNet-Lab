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

            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new {t.ProductId, t.CategoryId});





            #region Category Seed Data

            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Clothes",
                Description = "The best for winter",

            }
            , new Category()
            {
                Id = 2,
                Name = "Car",
                Description = "The best car"
            }
            , new Category()
            {
                Id = 3,
                Name = "Laptop",
                Description = "The best LAptop"
            }
            , new Category()
            {
                Id = 4,
                Name = "Books",
                Description = "The best Books"
            },
            new Category()
            {
                Id = 5,
                Name = "Laptop",
                Description = "The best Laptop"
            }
            );





            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }



}
