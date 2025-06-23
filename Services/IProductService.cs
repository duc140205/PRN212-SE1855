using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    public interface IProductService
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
    }
}
