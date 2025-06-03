using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2Object2
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_products()
        {
            products.Add(new Product() { Id = 1, Name = "P1", Quantity = 10, Price = 100 });
            products.Add(new Product() { Id = 2, Name = "P2", Quantity = 11, Price = 200 });
            products.Add(new Product() { Id = 3, Name = "P3", Quantity = 9, Price = 300 });
            products.Add(new Product() { Id = 4, Name = "P4", Quantity = 20, Price = 400 });
            products.Add(new Product() { Id = 5, Name = "P5", Quantity = 18, Price = 500 });
            products.Add(new Product() { Id = 6, Name = "P6", Quantity = 2, Price = 600 });
            products.Add(new Product() { Id = 7, Name = "P7", Quantity = 5, Price = 700 });
            products.Add(new Product() { Id = 8, Name = "P8", Quantity = 16, Price = 800 });
            products.Add(new Product() { Id = 9, Name = "P9", Quantity = 7, Price = 900 });
            products.Add(new Product() { Id = 10, Name = "P10", Quantity = 13, Price = 1000 });

        }
        public List<Product> FilterProductsByPrice(double price1, double price2)
        {
            return products.Where(p => p.Price >= price1 && p.Price <= price2)
                                .ToList();
        }
        public List<Product> FilterProductsByPrice2(double price1, double price2)
        {
            var results = from p in products
                          where p.Price >= price1 && p.Price <= price2
                          select p;
            return results.ToList();
        }
        public List<Product> SortProductsByPriceDescending()
        {
            return products.OrderByDescending(p => p.Price)
                                .ToList();
        }
        public List<Product> SortProductsByPriceDescending2()
        {
            var results = from p in products
                          orderby p.Price descending
                          select p;
            return results.ToList();
        }
        public double TotalValueOfProducts()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }

    }
}
