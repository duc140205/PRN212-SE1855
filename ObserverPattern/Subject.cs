using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Subject : ISubject
    {
        public int State { get; set; } = -0;

        private List<IObserver> _observers = new List<IObserver>();

        // Quản lý đăng ký observer
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // Gửi thông báo đến các observer
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        // Một số logic nghiệp vụ có thể thay đổi trạng thái
        public void SomeBusinessLogic()
        {
            // Giả sử thay đổi trạng thái và thông báo
            Console.WriteLine("Subjet: I'm doing something important.");
            State = new Random().Next(0, 10);
            Thread.Sleep(15);
            Console.WriteLine($"Subject: My State has just changed to {State}");
            Notify();
        }
    }
}
