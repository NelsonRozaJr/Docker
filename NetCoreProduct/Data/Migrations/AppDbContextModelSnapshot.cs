﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreProduct.Data;

namespace NetCoreProduct.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NetCoreProduct.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = "Category 01",
                            Name = "Product 01",
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 2,
                            Category = "Category 02",
                            Name = "Product 02",
                            Price = 15m
                        },
                        new
                        {
                            ProductId = 3,
                            Category = "Category 03",
                            Name = "Product 03",
                            Price = 13m
                        },
                        new
                        {
                            ProductId = 4,
                            Category = "Category 04",
                            Name = "Product 04",
                            Price = 11m
                        },
                        new
                        {
                            ProductId = 5,
                            Category = "Category 01",
                            Name = "Product 05",
                            Price = 19m
                        },
                        new
                        {
                            ProductId = 6,
                            Category = "Category 03",
                            Name = "Product 06",
                            Price = 15m
                        },
                        new
                        {
                            ProductId = 7,
                            Category = "Category 02",
                            Name = "Product 07",
                            Price = 16m
                        },
                        new
                        {
                            ProductId = 8,
                            Category = "Category 02",
                            Name = "Product 08",
                            Price = 19m
                        },
                        new
                        {
                            ProductId = 9,
                            Category = "Category 01",
                            Name = "Product 09",
                            Price = 20m
                        },
                        new
                        {
                            ProductId = 10,
                            Category = "Category 01",
                            Name = "Product 10",
                            Price = 14m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
