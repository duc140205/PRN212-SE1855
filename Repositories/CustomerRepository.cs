using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO customerDAO= new CustomerDAO();
        public void GenerateSampleDataset()
        {
           customerDAO.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
            return customerDAO.GetCustomers();
        }
    }
}
