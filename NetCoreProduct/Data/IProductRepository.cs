using System.Collections.Generic;
using NetCoreProduct.Models;

namespace NetCoreProduct.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}