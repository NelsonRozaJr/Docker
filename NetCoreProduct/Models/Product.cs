namespace NetCoreProduct.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public Product()
        {   
        }

        public Product(int productId, string name, string category, decimal price)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }
    }
}