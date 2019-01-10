using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericConstraint
    {
        /// <summary>
        /// 泛型约束：基类约束
        /// 1.在泛型方法内可以直接使用基类的属性和方法
        /// 2.在调用的时候，只能传递基类或基类的子类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) where T : People
        {
            Console.WriteLine("This is {0},paramter={1},type={2}",
                typeof(GenericMethod).Name, tParameter.GetType().Name, tParameter);
            Console.WriteLine("Id={0},Name={1}", tParameter.Id, tParameter.Name);
        }

        public static void ShowInterface<T>(T tParameter) where T : ISports
        {
            tParameter.Pingpang();
        }

        public static T Get<T>(T tParamter) 
            where T:new ()//无参数构造
        {
            T t = new T();
            return t;
        }

        //public static T Get<T>(T tParamter)
        //    where T : class//引用类型
        //{
        //    return null;
        //}
        //public static T Get<T>(T tParamter)
        //    where T : struct//值类型
        //{
        //    return default(T);
        //}
        public static void Many<T>()
            where T : People, ISports, IWork, new()
        {
            
        }
    }
}
