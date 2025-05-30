using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    // Observer cụ thể B
    public class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            int state = (subject as Subject).State;
            if (state == 0 || state >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
