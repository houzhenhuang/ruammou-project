using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印int值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }
        /// <summary>
        /// 打印string值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }
        /// <summary>
        /// 打印DateTime值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
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
                typeof(CommonMethod).Name, oParameter.GetType().Name, oParameter);
        }
    }
}
