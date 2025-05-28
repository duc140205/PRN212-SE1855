using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Customer
    {
        //cách viết POCO
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public void PrintInfor()
        {
            Console.BackgroundColor= ConsoleColor.Yellow;
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("###############################");
            Console.WriteLine($"Customer Id={Id}");
            Console.WriteLine($"Customer Name={Name}");
            Console.WriteLine($"Customer Email={Email}");
            Console.WriteLine($"Customer Phone={Phone}");
            Console.WriteLine($"Customer Address={Address}");
            Console.WriteLine("###############################");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
