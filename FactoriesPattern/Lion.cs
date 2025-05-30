using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; // using static directive

namespace FactoriesPattern
{
    public class Lion : IAnimal
    {
        public void AboutMe() => WriteLine("This is Lion.");
    }
}
