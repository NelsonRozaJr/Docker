using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiNetCore.Infrastructure.EntityType
{
    class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new CatalogType { Id = 1, Type = "CatalogType" },
                new CatalogType { Id = 2, Type = "Mug" },
                new CatalogType { Id = 3, Type = "T-Shirt" },
                new CatalogType { Id = 4, Type = "Sheet" },
                new CatalogType { Id = 5, Type = "USB Memory Stick" },
                new CatalogType { Id = 6, Type = "CatalogTypeTestOne" },
                new CatalogType { Id = 7, Type = "CatalogTypeTestTwo" }
            );
        }
    }
}
