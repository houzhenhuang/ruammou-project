using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("==============委托实现================");
            //Dog.DogWangHandler = new DogWang(Baby.Cry);
            //Dog.DogWangHandler += Thief.Run;
            Dog.DogWangHandler();
            //Dog.Wang();

            Console.WriteLine("==============事件实现================");
            Dog.DogWangHandlerEvent+= Baby.Cry;
            Dog.DogWangHandlerEvent+= Thief.Run;
            Dog.Wang();

            Console.Read();
        }
    }
}
