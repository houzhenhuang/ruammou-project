using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    /// <summary>
    /// 1 引入泛型:延迟声明
    /// 2 如何声明和使用泛型
    /// 3 泛型的好处和原理
    /// 4 泛型类、泛型方法、泛型接口、泛型委托
    /// 5 泛型约束
    /// 6 协变 逆变(选修)
    /// 泛型就是为了解决代码的重用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int iValue = 123;
                string sValue = "456";
                DateTime dtValue = DateTime.Now;
                object oValue = new object();

                Console.WriteLine(typeof(List<int>));
                Console.WriteLine(typeof(Dictionary<string, int>));
                Console.WriteLine("*************************************");
                CommonMethod.ShowInt(iValue);
                CommonMethod.ShowString(sValue);
                CommonMethod.ShowDateTime(dtValue);


                Console.WriteLine("*************************************");
                CommonMethod.ShowObject(oValue);

                CommonMethod.ShowObject(iValue);
                CommonMethod.ShowObject(sValue);
                CommonMethod.ShowObject(dtValue);

                Console.WriteLine("*************************************");
                GenericMethod.Show<object>(oValue);
                GenericMethod.Show<int>(iValue);
                GenericMethod.Show(iValue);//类型参数可以省略，由编译器推断
                GenericMethod.Show<string>(sValue);
                GenericMethod.Show<DateTime>(dtValue);
                Console.WriteLine("*************************************");

                GenericConstraint.Show<People>(new People { Id = 1001, Name = "lucy" });
                GenericConstraint.Show<Chinese>(new Chinese { Id = 1002, Name = "Coco" });
                GenericConstraint.Show<JiangXi>(new JiangXi { Id = 1003, Name = "Jack" });
                //GenericConstraint.Show<int>(1);//约束后，只能按约束传递

                //GenericConstraint.ShowInterface<People>(new People { Id = 1001, Name = "lucy" });
                GenericConstraint.ShowInterface<Chinese>(new Chinese { Id = 1002, Name = "Coco" });
                GenericConstraint.ShowInterface<JiangXi>(new JiangXi { Id = 1003, Name = "Jack" });
                GenericConstraint.ShowInterface<Japanese>(new Japanese { Id = 1004, Name = "鬼子" });
                #region Monitor
                long commonTime = 0;
                long objectTime = 0;
                long genericTime = 0;
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < 1000000000; i++)
                    {
                        ShowCommon(iValue);
                    }
                    stopwatch.Stop();
                    commonTime = stopwatch.ElapsedMilliseconds;
                
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < 1000000000; i++)
                    {
                        ShowObject(oValue);//装箱，值类型是分配在栈上的，引用类型是分配在堆上的
                    }
                    stopwatch.Stop();
                    objectTime = stopwatch.ElapsedMilliseconds;
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < 1000000000; i++)
                    {
                        ShowGeneric<int>(iValue);
                    }
                    stopwatch.Stop();
                    genericTime = stopwatch.ElapsedMilliseconds;
                }
                Console.WriteLine("commonTime={0}    objectTime={1}    genericTime={2}", commonTime, objectTime, genericTime);

                #endregion

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
        private static void ShowCommon(int iParamter) { }
        private static void ShowObject(object oParamter) { }
        private static void ShowGeneric<T>(T tParamter) { }
    }
}
