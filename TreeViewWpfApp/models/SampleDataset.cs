using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class SampleDataset
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category electronics = new Category { Id = 1, Name = "Electronics" };
            electronics.Products.Add(1, new Product { Id = 1, Name = "Smartphone", Quantity = 50, Price = 699.99 });
            electronics.Products.Add(2, new Product { Id = 2, Name = "Laptop", Quantity = 30, Price = 999.99 });
            electronics.Products.Add(3, new Product { Id = 3, Name = "Smartwatch", Quantity = 20, Price = 199.99 });
            Category clothing = new Category { Id = 2, Name = "Clothing" };
            clothing.Products.Add(4, new Product { Id = 4, Name = "T-Shirt", Quantity = 100, Price = 19.99 });
            clothing.Products.Add(5, new Product { Id = 5, Name = "Jeans", Quantity = 80, Price = 49.99 });
            clothing.Products.Add(6, new Product { Id = 6, Name = "Jacket", Quantity = 40, Price = 89.99 });
            Category groceries = new Category { Id = 3, Name = "Groceries" };
            groceries.Products.Add(7, new Product { Id = 7, Name = "Apple", Quantity = 200, Price = 0.99 });
            groceries.Products.Add(8, new Product { Id = 8, Name = "Bread", Quantity = 150, Price = 1.99 });
            groceries.Products.Add(9, new Product { Id = 9, Name = "Milk", Quantity = 100, Price = 0.89 });
            categories.Add(electronics.Id, electronics);
            categories.Add(clothing.Id, clothing);
            categories.Add(groceries.Id, groceries);
            return categories;

        }
    }
}
