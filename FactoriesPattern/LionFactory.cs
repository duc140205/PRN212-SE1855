using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriesPattern
{
    // LionFactory is used to create Lions
    public class LionFactory : AnimalFactory
    {
        // Creating a Lion
        public override IAnimal CreateAnimal() => new Lion();
    }
}
