using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*************************用观察者模式实现************************");
                {//基于观察者模式实现
                    Cat cat = new Cat();
                    cat.Add(new Dog());
                    cat.Add(new Mouse());
                    cat.Add(new Baby());
                    cat.MiaoToOberver();
                }
                Console.WriteLine("*************************用委托实现************************");
                {
                    Cat cat = new Cat();
                    cat.action += () => new Dog().Wang();
                    cat.action += () => new Mouse().Hide();
                    cat.action += () => new Baby().Cry();
                    cat.MiaoToDelegate();
                }
                Console.WriteLine("*************************用委托事件实现************************");
                {
                    Cat cat = new Cat();
                    cat.actionEvent += () => new Dog().Wang();
                    cat.actionEvent += () => new Mouse().Hide();
                    cat.actionEvent += () => new Baby().Cry();
                    cat.MiaoToDelegateEvent();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
