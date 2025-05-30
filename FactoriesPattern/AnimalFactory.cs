using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoriesPattern
{
    public abstract class AnimalFactory
    {
        /*
        Factory method lets a class defer instantiation to subclasses.
        The following method will create a Tiger or a Lion,
        but at this point it does not know whether it will get a Lion or a tiger.
        It will be decided by the subclasses i.e. LionFactory or TigerFactory.
        So, the following method is acting like a factory (of creation).
        */
        public abstract IAnimal CreateAnimal();
    }

}
