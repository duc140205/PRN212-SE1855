using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Product> GetProductsByCategory(int categoryId);
    }
}
