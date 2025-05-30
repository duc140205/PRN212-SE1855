using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Bentley : Car
    {
        public Bentley(string model) => (ModelName, BasePrice) = (model, 300_000);

        // Tạo bản sao nông (shallow copy)
        public override Car Clone() => this.MemberwiseClone() as Bentley;
    }
}
