using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace MyLambda
{
    /// <summary>
    /// 本质：Lmabda表达式就是一个方法
    /// </summary>
    public delegate void NoReturnNoPara();
    public delegate void NoReturnWithPara(string name, DateTime now);
    public delegate string WithReturnNoPara();
    public delegate int WithReturnWithoPara(int x,int y);
    public class LambdaShow
    {
        public static void Show()
        {
            NoReturnWithPara method = new NoReturnWithPara(Study);//委托实例化，要求传入的方法必须满足委托的约束
            method.Invoke("jack",DateTime.Now);

            NoReturnWithPara method1 = new NoReturnWithPara(
                delegate(string name,DateTime now) {
                    Console.WriteLine("{0}{1}正在学习Lambda表达式", name, now);
                });//使用匿名方法，把方法名去掉
            method1.Invoke("jack", DateTime.Now);

            NoReturnWithPara method2 = new NoReturnWithPara(
               (string name, DateTime now)=>
               {
                   Console.WriteLine("{0}{1}正在学习Lambda表达式", name, now);
               });//Lmabda表达式   把delegate换成了=>
            method2.Invoke("jack", DateTime.Now);

            NoReturnWithPara method3 = new NoReturnWithPara(
               (name, now) =>
               {
                   Console.WriteLine("{0}{1}正在学习Lambda表达式", name, now);
               });//去掉了参数类型，委托实例化要求传入的方法必须满足委托的约束
            method3.Invoke("jack", DateTime.Now);


            NoReturnWithPara method4 = (name, now) =>
               {
                   Console.WriteLine("{0}{1}正在学习Lambda表达式", name, now);
               };//去掉了new NoReturnWithPara();
            method4.Invoke("jack", DateTime.Now);

            NoReturnWithPara method5 = (name, now) => Console.WriteLine("{0}{1}正在学习Lambda表达式", name, now);
            //去掉了{},条件是方法体只有一行;
            method5.Invoke("jack", DateTime.Now);


            NoReturnWithPara method10 = (s, b) => Console.WriteLine("{0}{1}正在学习Lambda表达式", s, b);
            method10.Invoke("jack", DateTime.Now);

            Console.WriteLine("===============================================");

            WithReturnWithoPara func = (x, y) => { return x * y; };
            WithReturnWithoPara func1 = (x, y) => x * y;//去掉了{},条件是方法体只有一行,带返回值的话，return就去掉;
            func.Invoke(3,4);
            func1.Invoke(3, 4);

            Console.WriteLine("===============================================");

            NoReturnNoPara action = () => { };
            NoReturnNoPara action1 = () => { Console.WriteLine("12345"); };

            Console.WriteLine("===============================================");
            WithReturnNoPara fun = () => "erfdfa";
            Console.WriteLine("===============================================");
            //系统自带的各种委托
            #region 不带返回值的委托
            Action act1 = () => { };
            //泛型委托
            Action<string> act2 = name => { Console.WriteLine(); };//一个参数的话，可以去掉小括号
            //最多可以有16个参数
            Action<string, int, long, DateTime, char, double, decimal> act3 = (par1, par2, par3, par4, par5, par6, par7) => { }; 
            #endregion

            #region 带返回值的委托
            Func<string> fun1 = () => "fdafds";
            Func<DateTime> fun2 = () => DateTime.Now;
            //最多可以有16个参数,带一个返回值
            Func<string, int, long, DateTime, char, double, decimal, DateTime> fun3 = (par1, par2, par3, par4, par5, par6, par7) => DateTime.Now;
            Func<string, int, long, DateTime, char, double, decimal, Action> fun4 = (par1, par2, par3, par4, par5, par6, par7) => act1;



            #endregion

        }

        public static void LinqShow() 
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            foreach (var item in list.Where<int>(p => p > 55))
            {
                Console.WriteLine(item);   
            }
        }
        private static void Study(string name,DateTime now) 
        {
            Console.WriteLine("{0}{1}正在学习Lambda表达式",name,now);
        }
    }
}
