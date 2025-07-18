using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();
        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return productDAO.GetProductsByCategory(categoryId);
        }
        public bool SaveProduct(Product product)
        {
            return productDAO.SaveProduct(product);
        }
        public bool UpdateProduct(Product product)
        {
            return productDAO.UpdateProduct(product);
        }
        public bool DeleteProduct(int productId)
        {
            return productDAO.DeleteProduct(productId);
        }
    }
}
