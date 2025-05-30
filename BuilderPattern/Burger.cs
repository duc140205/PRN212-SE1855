using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    using System;

    // Product
    public class Burger
    {
        public string Bun { get; set; }
        public string Patty { get; set; }
        public bool Cheese { get; set; }
        public bool Lettuce { get; set; }
        public bool Tomato { get; set; }

        public override string ToString()
        {
            return $"Burger with: {Bun} bun, {Patty} patty" +
                   (Cheese ? ", cheese" : "") +
                   (Lettuce ? ", lettuce" : "") +
                   (Tomato ? ", tomato" : "");
        }
    }
}
