using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Cat
    {
        List<IObserver> observer = new List<IObserver>();

        public void Add(IObserver ober)
        {
            observer.Add(ober);
        }
        public void MiaoToOberver()
        {
            Console.WriteLine("猫喵了一声。。。");
            if (observer.Count > 0)
                observer.ForEach(t => t.DoAction());
        }

        public Action action = null;
        public void MiaoToDelegate()
        {
            Console.WriteLine("猫喵了一声。。。");
            if (action != null)
                action.Invoke();
        }

        public event Action actionEvent = null; 
        public void MiaoToDelegateEvent()
        {
            Console.WriteLine("猫喵了一声。。。");
            if (actionEvent != null)
                actionEvent.Invoke();
        }
    }
}
