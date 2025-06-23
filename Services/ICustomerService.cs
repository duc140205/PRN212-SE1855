using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
namespace Services
{
    public interface ICustomerService
    {
        public void GenerateSampleDataset();
        public List<Customer> GetCustomers();
    }
}
