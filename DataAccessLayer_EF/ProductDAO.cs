using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class ProductDAO
    {
        MyStoreContext context = new MyStoreContext();
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return context.Products
                            .Where(p => p.CategoryId == categoryId)
                            .ToList();
        }
    }
}
