using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreProduct.Models;

namespace NetCoreProduct.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product[]
            {
                new Product { ProductId = 1, Name = "Product 01", Category = "Category 01", Price = 10M },
                new Product { ProductId = 2, Name = "Product 02", Category = "Category 02", Price = 15M },
                new Product { ProductId = 3, Name = "Product 03", Category = "Category 03", Price = 13M },
                new Product { ProductId = 4, Name = "Product 04", Category = "Category 04", Price = 11M },
                new Product { ProductId = 5, Name = "Product 05", Category = "Category 01", Price = 19M },
                new Product { ProductId = 6, Name = "Product 06", Category = "Category 03", Price = 15M },
                new Product { ProductId = 7, Name = "Product 07", Category = "Category 02", Price = 16M },
                new Product { ProductId = 8, Name = "Product 08", Category = "Category 02", Price = 19M },
                new Product { ProductId = 9, Name = "Product 09", Category = "Category 01", Price = 20M },
                new Product { ProductId = 10, Name = "Product 10", Category = "Category 01", Price = 14M }
            });
        }
    }
}