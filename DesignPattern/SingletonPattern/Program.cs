using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Singleton singleton = Singleton.CreateInstance();
                    //    singleton.WriteText();
                    //}
                }              
                {
                    //TaskFactory taskFactory = new TaskFactory();
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    taskFactory.StartNew(() =>
                    //    {
                    //        Singleton singleton = Singleton.CreateInstance();
                    //        singleton.WriteText();
                    //    });
                    //}
                }
                {
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    SingletonSecond singleton = SingletonSecond.CreateInstance();
                    //    singleton.WriteText();
                    //}

                    TaskFactory taskFactory = new TaskFactory();
                    for (int i = 0; i < 5; i++)
                    {
                        taskFactory.StartNew(() =>
                        {
                            SingletonThird singleton = SingletonThird.CreateInstance();
                            singleton.WriteText();
                        });
                    }
                }       

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
