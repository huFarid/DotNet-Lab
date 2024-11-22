﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop_DotNetCore.Data;

#nullable disable

namespace Shop_DotNetCore.Migrations
{
    [DbContext(typeof(MyEshopContext))]
    [Migration("20241122114740_rr")]
    partial class rr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop_DotNetCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The best for winter",
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The best car",
                            Name = "Car"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The best LAptop",
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The best Books",
                            Name = "Books"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The best Home",
                            Name = "Home"
                        });
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryToProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 5
                        });
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Price = 10m,
                            QuantityInStock = 22
                        },
                        new
                        {
                            ID = 2,
                            Price = 10m,
                            QuantityInStock = 22
                        },
                        new
                        {
                            ID = 3,
                            Price = 10m,
                            QuantityInStock = 22
                        });
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemID")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemID = 1,
                            Name = "Course 1"
                        },
                        new
                        {
                            Id = 2,
                            ItemID = 2,
                            Name = "Course 2"
                        },
                        new
                        {
                            Id = 3,
                            ItemID = 3,
                            Name = "Course 3"
                        });
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.CategoryToProduct", b =>
                {
                    b.HasOne("Shop_DotNetCore.Models.Category", "Category")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop_DotNetCore.Models.Product", "Product")
                        .WithMany("CategoryToProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Product", b =>
                {
                    b.HasOne("Shop_DotNetCore.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("Shop_DotNetCore.Models.Product", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Category", b =>
                {
                    b.Navigation("CategoryToProducts");
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Item", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("Shop_DotNetCore.Models.Product", b =>
                {
                    b.Navigation("CategoryToProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
