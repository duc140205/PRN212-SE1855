using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface ISubject
    {
        void Attach(IObserver observer);   // Thêm observer
        void Detach(IObserver observer);   // Gỡ observer
        void Notify();                     // Gửi thông báo cho tất cả observers
    }

}
