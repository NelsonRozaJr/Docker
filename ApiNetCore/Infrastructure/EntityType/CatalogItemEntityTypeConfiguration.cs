using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore.Infrastructure.EntityType
{
    class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.PictureFileName)
                .IsRequired(false);

            builder.Ignore(ci => ci.PictureUri);

            builder.HasOne(ci => ci.CatalogBrand)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogBrandId);

            builder.HasOne(ci => ci.CatalogType)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogTypeId);

            builder.HasData(
                new CatalogItem { Id = 1, CatalogTypeId = 3, CatalogBrandId = 3, Description = ".NET Bot Black Hoodie, and more", Name = ".NET Bot Black Hoodie", Price = 19.5M, PictureFileName = "1.png", AvailableStock = 100, OnReorder = false },
                new CatalogItem { Id = 2, CatalogTypeId = 2, CatalogBrandId = 3, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", Price = 8.50M, PictureFileName = "2.png", AvailableStock = 89, OnReorder = true },
                new CatalogItem { Id = 3, CatalogTypeId = 3, CatalogBrandId = 6, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", Price = 12M, PictureFileName = "3.png", AvailableStock = 56, OnReorder = false },
                new CatalogItem { Id = 4, CatalogTypeId = 3, CatalogBrandId = 3, Description = ".NET Foundation T-shirt", Name = ".NET Foundation T-shirt", Price = 12M, PictureFileName = "4.png", AvailableStock = 120, OnReorder = false },
                new CatalogItem { Id = 5, CatalogTypeId = 4, CatalogBrandId = 6, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", Price = 8.5M, PictureFileName = "5.png", AvailableStock = 55, OnReorder = false },
                new CatalogItem { Id = 6, CatalogTypeId = 3, CatalogBrandId = 3, Description = ".NET Blue Hoodie", Name = ".NET Blue Hoodie", Price = 12M, PictureFileName = "6.png", AvailableStock = 17, OnReorder = false },
                new CatalogItem { Id = 7, CatalogTypeId = 3, CatalogBrandId = 6, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", Price = 12M, PictureFileName = "7.png", AvailableStock = 8, OnReorder = false },
                new CatalogItem { Id = 8, CatalogTypeId = 3, CatalogBrandId = 6, Description = "Kudu Purple Hoodie", Name = "Kudu Purple Hoodie", Price = 8.5M, PictureFileName = "8.png", AvailableStock = 34, OnReorder = false },
                new CatalogItem { Id = 9, CatalogTypeId = 2, CatalogBrandId = 6, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", Price = 12M, PictureFileName = "9.png", AvailableStock = 76, OnReorder = false },
                new CatalogItem { Id = 10, CatalogTypeId = 4, CatalogBrandId = 3, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", Price = 12M, PictureFileName = "10.png", AvailableStock = 11, OnReorder = false },
                new CatalogItem { Id = 11, CatalogTypeId = 4, CatalogBrandId = 3, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", Price = 8.5M, PictureFileName = "11.png", AvailableStock = 3, OnReorder = false },
                new CatalogItem { Id = 12, CatalogTypeId = 3, CatalogBrandId = 6, Description = "Prism White TShirt", Name = "Prism White TShirt", Price = 12M, PictureFileName = "12.png", AvailableStock = 0, OnReorder = false },
                new CatalogItem { Id = 13, CatalogTypeId = 2, CatalogBrandId = 6, Description = "De los Palotes", Name = "pepito", Price = 12M, PictureFileName = "13.png", AvailableStock = 0, OnReorder = false });
        }
    }
}
