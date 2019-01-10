using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    public delegate  void DogWang();
    public class Dog
    {
        public static DogWang DogWangHandler;
        public static event DogWang DogWangHandlerEvent;//事件的本质就是委托的一个实例。加了event关键字
        public static void Wang() 
        {
            Console.WriteLine("狗汪汪汪汪");

            if (DogWangHandler != null)
                DogWangHandler.Invoke();

            if (DogWangHandlerEvent != null)
                DogWangHandlerEvent.Invoke();
        }
    }
}
