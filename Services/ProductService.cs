using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository irepository;
        public ProductService()
        {
            irepository = new ProductRepository();
        }
        public void GenerateSampleDataset()
        {
            irepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return irepository.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return irepository.SaveProduct(product);
        }
    }
}
