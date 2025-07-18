using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        public ProductService()
        {
            productRepository = new ProductRepository();
        }
        public List<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return productRepository.GetProductsByCategory(categoryId);
        }
        public bool SaveProduct(Product product)
        {
            return productRepository.SaveProduct(product);
        }
        public bool UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(int productId)
        {
            return productRepository.DeleteProduct(productId);
        }
    }
}
