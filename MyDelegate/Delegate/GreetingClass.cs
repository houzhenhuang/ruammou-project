using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void DelGreeting(string name);
    /// <summary>
    /// 委托：解耦
    /// </summary>
    public class GreetingClass
    {
        public static void GreetingChinese(string name) 
        {
            Console.WriteLine("{0},早上好", name);
        }
        public static void GreetingEnglish(string name)
        {
            Console.WriteLine("{0},Moring", name);
        }
        public static void Greeting(string name, DelGreeting greeting)//对扩展开放，对修改封闭
        {
            greeting.Invoke(name);
        }

    }
}
