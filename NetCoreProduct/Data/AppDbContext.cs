using Microsoft.EntityFrameworkCore;
using NetCoreProduct.Configuration;
using NetCoreProduct.Models;

namespace NetCoreProduct.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());            
        }
    }
}