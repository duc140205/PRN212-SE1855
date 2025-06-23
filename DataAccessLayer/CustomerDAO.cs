using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();

        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name = "Obama", Phone = "0934932911" });
            customers.Add(new Customer() { Id = 2, Name = "Trump", Phone = "0934932912" });
            customers.Add(new Customer() { Id = 3, Name = "Biden", Phone = "0934932913" });
            customers.Add(new Customer() { Id = 4, Name = "Hillary", Phone = "0934932914" });
            customers.Add(new Customer() { Id = 5, Name = "Bush", Phone = "0934932915" });
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
    }
