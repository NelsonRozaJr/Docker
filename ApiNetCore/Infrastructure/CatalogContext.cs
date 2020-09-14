using ApiNetCore.Infrastructure.EntityType;
using ApiNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCore.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<CatalogType> CatalogTypes { get; set; }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
        }
    }
}
