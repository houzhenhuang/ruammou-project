using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Mouse : IObserver
    {
        public void Hide() 
        {
            Console.WriteLine("老鼠藏起来了。。。");
        }

        public void DoAction()
        {
            this.Hide();
        }
    }
}
