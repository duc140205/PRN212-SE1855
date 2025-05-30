using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // Builder interface
    public interface IBurgerBuilder
    {
        IBurgerBuilder SetBun(string type);
        IBurgerBuilder SetPatty(string type);
        IBurgerBuilder AddCheese();
        IBurgerBuilder AddLettuce();
        IBurgerBuilder AddTomato();
        Burger Build();
    }

}
