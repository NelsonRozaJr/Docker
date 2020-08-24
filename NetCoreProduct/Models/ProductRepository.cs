using System.Collections.Generic;

namespace NetCoreProduct.Models
{
    public class ProductRepository : IProductRepository
    {
        private static IEnumerable<Product> MockData = new List<Product>
        {
            new Product { ProductId = 10, Name = "Caneta", Category = "Material", Price = 2M },
            new Product { ProductId = 20, Name = "Borracha", Category = "Material", Price = 1.50M },
            new Product { ProductId = 30, Name = "Estojo", Category = "Material", Price = 3M }
        };

        public IEnumerable<Product> Products => MockData;
    }
}