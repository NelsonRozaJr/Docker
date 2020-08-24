using System.Collections.Generic;

namespace NetCoreProduct.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}