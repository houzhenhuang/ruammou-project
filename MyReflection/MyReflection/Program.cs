using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyReflection.DB.Interface;
using MyReflection.DB.SqlService;
using System.Reflection;
using System.Configuration;
using MyReflection.Model;

namespace MyReflection
{
    /// <summary>
    /// 反射是什么：反射就是.NET Framework框架为我们提供的一个帮助类库，它可以读取我们编译生成的dll文件里的metadata信息
    /// 1.反射的介绍和
    ///     反射就是为了动态，动态的调用dll，动态的创建对象，动态的调用方法等等。。。
    ///     反射的原理：一个类库编译后成后两个文件，dll和pdb，pdb是一个调试用的文件，没有太大意义。dll是个应用程序扩展。
    ///     dll包含两部分，一部分是IL(中间语言),另一部分叫metadata(元数据)。
    ///     IL:和计算计交互的数据
    ///     metadata：对IL的描述，描述IL里面有什么信息，比如：有哪些类，哪些方法。。。
    /// 2.通过反射获取信息，创建对象、调用方法
    /// 3.实现程序的可配置
    /// 
    /// 4.依赖接口，完成可配置扩展:=>不修改原来的代码，增加功能
    /// 5.去掉接口，反射调用方法，包括私用方法
    /// 6.反射破坏单例
    /// 反射的好处和局限
    ///     1.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Common
                {
                    Console.WriteLine("================Common=================");
                    IDBHelper dbHelper = new SqlServerHelper();
                    dbHelper.Query();
                }
                #endregion

                #region Reflection
                {
                    //Assembly assembly = Assembly.Load("MyReflection.DB.SqlService");
                    ////Assembly assemblyFile = Assembly.LoadFile(@"F:\Ruanmou\Study\MyReflection\MyReflection.DB.SqlService\bin\Debug\MyReflection.DB.SqlService.dll");//完全限定名和后缀
                    ////Assembly assemblyFrom = Assembly.LoadFrom(@"F:\Ruanmou\Study\MyReflection\MyReflection.DB.SqlService\bin\Debug\MyReflection.DB.SqlService.dll");//可以是绝对路径，也可以是相对路径，但是要带后缀
                    //foreach (var item in assembly.GetModules())
                    //{
                    //    Console.WriteLine("Module完全限定名:" + item.FullyQualifiedName);
                    //}
                    //foreach (var type in assembly.GetTypes())//遍历该dll下的所有类型
                    //{
                    //    Console.WriteLine("Type完全限定名:" + type.FullName);
                    //    foreach (var item in type.GetConstructors())//遍历类型下的所有构造函数
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                    //    foreach (var item in type.GetMethods())//遍历类型下的所有公开方法
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                    //    foreach (var item in type.GetProperties())//遍历类型下的所有公开属性
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                    //    foreach (var item in type.GetFields())//遍历类型下的所有公开字段
                    //    {
                    //        Console.WriteLine(item.Name);
                    //    }
                    //}
                }
                #endregion

                #region Application
                {
                    {
                        //Console.WriteLine("=======================================");
                        //Assembly assembly = Assembly.Load("MyReflection.DB.SqlService");//1.动态加载dll
                        //Type typeHelper = assembly.GetType("MyReflection.DB.SqlService.SqlServerHelper");//2.获取类型信息
                        //object objDbHelper = Activator.CreateInstance(typeHelper);//3.创建对象
                        ////((SqlServiceHelper)objDbHelper).Query();
                        //IDBHelper dbHelper = (IDBHelper)objDbHelper;
                        //dbHelper.Query();
                    }
                    //{
                    //    //简单工厂+配置文件+反射=Ioc
                    //    IDBHelper dbHelper = SimpleFactory.CreateDBHelper();
                    //    dbHelper.Query();
                    //}
                    ////破坏单例  调用私有构造函数
                    //{
                    //    Assembly assembly = Assembly.Load("MyReflection.DB.SqlService");//1.动态加载dll
                    //    Type typeHelper = assembly.GetType("MyReflection.DB.SqlService.Singleton");//2.获取类型信息
                    //    object objDbHelper = Activator.CreateInstance(typeHelper, true);//3.创建对象
                    //}
                    ////创建泛型的实例
                    //{
                    //    Assembly assembly = Assembly.Load("MyReflection.DB.SqlService");//1.动态加载dll
                    //    Type typeHelper = assembly.GetType("MyReflection.DB.SqlService.GenericClass`3");//2.获取类型信息
                    //    Type newType = typeHelper.MakeGenericType(typeof(int), typeof(int), typeof(int));
                    //    object objDbHelper = Activator.CreateInstance(newType);//3.创建对象
                    //}
                }
                #endregion

                #region 反射调用实例方法、静态方法、重载方法  选修：调用私有方法，调用泛型方法
                {
                    //Assembly assembly = Assembly.Load("MyReflection.DB.SqlService");//1.动态加载dll
                    //Type typeHelper = assembly.GetType("MyReflection.DB.SqlService.ReflectionTest");//2.获取类型信息
                    //object objDbHelper = Activator.CreateInstance(typeHelper);//3.创建对象

                    //MethodInfo show1 = typeHelper.GetMethod("show1");
                    //show1.Invoke(objDbHelper, null);

                    //MethodInfo show2 = typeHelper.GetMethod("show2");
                    //show2.Invoke(objDbHelper, new object[] { 11 });

                    //MethodInfo show3_1 = typeHelper.GetMethod("show3", new Type[] { typeof(string) });
                    //show3_1.Invoke(objDbHelper, new object[] { "dafs" });

                    //MethodInfo show3_2 = typeHelper.GetMethod("show3", new Type[] { typeof(int) });
                    //show3_2.Invoke(objDbHelper, new object[] { 111 });

                    //MethodInfo show3_3 = typeHelper.GetMethod("show3", new Type[] { typeof(int), typeof(string) });
                    //show3_3.Invoke(objDbHelper, new object[] { 111, "dfafsd" });

                    //MethodInfo show4 = typeHelper.GetMethod("show4", BindingFlags.Instance |//访问私有方法
                    //    BindingFlags.Public | BindingFlags.NonPublic);
                    //show4.Invoke(objDbHelper, new object[] { "dfafsd" });

                    //MethodInfo show5 = typeHelper.GetMethod("show5");//静态方法
                    //show5.Invoke(null, new object[] { "dfafsd" });//不放对象
                    //show5.Invoke(objDbHelper, new object[] { "dfafsd" });//放对象
                }
                #endregion

                #region 反射字段和属性，分别获取值和设置值
                //ORM
                {
                    {
                        People people = new People
                        {
                            Id = 1001,
                            Name = "张三"
                        };
                       //Console.WriteLine("Id={0},Name={1}", people.Id, people.Name);
                    }
                    {
                        Type type = typeof(People);
                        object oPeople = Activator.CreateInstance(type);
                        foreach (var item in type.GetProperties())//字段设置和获取的语法和属性一样
                        {
                            Console.WriteLine("{0}={1}", item.Name, item.GetValue(oPeople));
                            if (item.Name.Equals("Id"))
                            {
                                item.SetValue(oPeople, 1002);
                            }
                            if (item.Name.Equals("Name"))
                            {
                                item.SetValue(oPeople, "李四");
                            }
                            Console.WriteLine("{0}={1}", item.Name, item.GetValue(oPeople));
                        }
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
