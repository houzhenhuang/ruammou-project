using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Dog : IObserver
    {
        public void Wang() 
        {
            Console.WriteLine("狗汪了一声。。。");
        }

        public void DoAction()
        {
            this.Wang();
        }
    }
}
