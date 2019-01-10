using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericMethod
    {
        /// <summary>
        /// 延迟声明：把参数类型的声明推迟到调用
        /// 不是语法糖，而是由框架升级提供的功能
        /// 语法糖：由编译器提供的一些功能，我们写的简单的语法，由编译器编译成复杂的代码（代码改写）比如：Lambda表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(GenericMethod).Name, tParameter.GetType().Name, tParameter);
        }

        /// <summary>
        /// 打印Object值
        /// 1.继承
        ///     任何父类出现的地方，都可以使用子类来替换(里氏替换原则)
        ///     object是一切类型的父类
        /// 2.多态
        /// 3.封装
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(GenericMethod).Name, oParameter.GetType().Name, oParameter);
        }
    }
}
