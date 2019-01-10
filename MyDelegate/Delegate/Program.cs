using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /// <summary>
    /// 委托三部曲
    /// 1、声明一个委托
    /// 2、实例化委托
    /// 3、调用
    /// </summary>
    class Program
    {
        //1、声明一个委托
        public delegate int MyDelegate(string str);//该委托可被任何一个与其且有相同标签（类型参数和返回相同类型）的方法
        static void Main(string[] args)
        {
            //2、实例化委托
            MyDelegate del = new MyDelegate(getStrLenth);

            MyDelegate del2 = getStrLenth;//实例化简写

            //3、调用
            Console.WriteLine(del.Invoke("hello delegate!"));
            Console.WriteLine(del("hello delegate!"));

            //GreetingClass.GreetingChinese("中国人");
            //GreetingClass.GreetingChinese("hello");
            DelGreeting delGreeting = new DelGreeting(GreetingClass.GreetingEnglish);
            GreetingClass.Greeting("hello", delGreeting);



            Console.ReadKey();
        }

        static int getStrLenth(string str) { return str.Length; }

    }
}
