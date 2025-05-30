using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Mustang : Car
    {
        public Mustang(string model) => (ModelName, BasePrice) = (model, 200_000);

        // Tạo bản sao nông (shallow copy)
        public override Car Clone() => this.MemberwiseClone() as Mustang;
    }
}
