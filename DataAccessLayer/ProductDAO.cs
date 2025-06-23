using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccessLayer
{
    public class ProductDAO
    {
      static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 2, Name = "Smartphone", Quantity = 20, Price = 499.99 });
            products.Add(new Product { Id = 3, Name = "Tablet", Quantity = 15, Price = 299.99 });
            products.Add(new Product { Id = 4, Name = "Smartwatch", Quantity = 25, Price = 199.99 });
            products.Add(new Product { Id = 5, Name = "Headphones", Quantity = 30, Price = 99.99 });
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
                return false;//vì trùng mã nên ko phải thêm mới
            //thêm mới:
            products.Add(product);
            return true;
        }
    }
}
