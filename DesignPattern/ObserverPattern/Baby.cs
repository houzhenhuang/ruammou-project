using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Baby : IObserver
    {
        public void Cry() 
        {
            Console.WriteLine("baby哭了。。。");
        }

        public void DoAction()
        {
            this.Cry();
        }
    }
}
