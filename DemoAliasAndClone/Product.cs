using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAliasAndClone
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Quantity}\t{Price}";
        }
        public Product clone()
        {
            return MemberwiseClone() as Product; // MemberwiseClone() tạo ra một bản sao nông (shallow copy)
                                                 // của đối tượng hiện tại
        }
    }
}
