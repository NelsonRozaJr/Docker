using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiNetCore.Infrastructure.EntityType
{
    class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new CatalogBrand { Id = 1, Brand = "CatalogBrand" },
                new CatalogBrand { Id = 2, Brand = "Azure" },
                new CatalogBrand { Id = 3, Brand = ".NET" },
                new CatalogBrand { Id = 4, Brand = "Visual Studio" },
                new CatalogBrand { Id = 5, Brand = "SQL Server" },
                new CatalogBrand { Id = 6, Brand = "Other" },
                new CatalogBrand { Id = 7, Brand = "CatalogBrandTestOne" },
                new CatalogBrand { Id = 8, Brand = "CatalogBrandTestTwo" }
            );
        }
    }
}
