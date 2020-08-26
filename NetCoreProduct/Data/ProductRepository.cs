using System.Collections.Generic;
using NetCoreProduct.Models;

namespace NetCoreProduct.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products => _context.Products;
    }
}