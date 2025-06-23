using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository icustomerRepository;
        public CustomerService()
        {
            icustomerRepository = new CustomerRepository();
        }
        public void GenerateSampleDataset()
        {
            icustomerRepository.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
           return icustomerRepository.GetCustomers();
        }
    }
}
