using System.Collections.Generic;

namespace AppTeste.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public static Product[] GetProducts()
        {
            Product kayak = new Product { Name = "Kayak", Price = 275M };
            Product lifejacket = new Product { Name = "Lifejacket", Price = 48.95M };
            return new Product[] { kayak, lifejacket };
        }
    }
    //parece que é so para simular uma Interface tipo IREPo
    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products => new Product[]
        {
             new Product { Name = "Kayak", Price = 275M },
             new Product { Name = "Lifejacket", Price = 48.95M }
        };
    }
}