using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Concrete Builder
    public class BurgerBuilder : IBurgerBuilder
    {
        private Burger _burger = new Burger();

        public IBurgerBuilder SetBun(string type)
        {
            _burger.Bun = type;
            return this;
        }

        public IBurgerBuilder SetPatty(string type)
        {
            _burger.Patty = type;
            return this;
        }

        public IBurgerBuilder AddCheese()
        {
            _burger.Cheese = true;
            return this;
        }

        public IBurgerBuilder AddLettuce()
        {
            _burger.Lettuce = true;
            return this;
        }

        public IBurgerBuilder AddTomato()
        {
            _burger.Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return _burger;
        }
    }

}
