using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Chef
    {
        private IBurgerBuilder _builder;

        public Chef(IBurgerBuilder builder)
        {
            _builder = builder;
        }

        public Burger MakeCheeseBurger()
        {
            return _builder
                .SetBun("Sesame")
                .SetPatty("Beef")
                .AddCheese()
                .Build();
        }

        public Burger MakeVeggieBurger()
        {
            return _builder
                .SetBun("Whole Wheat")
                .SetPatty("Veggie")
                .AddLettuce()
                .AddTomato()
                .Build();
        }
    }
}
