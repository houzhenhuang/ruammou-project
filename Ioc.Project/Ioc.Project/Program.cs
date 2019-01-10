using Ioc.Interface;
using Ioc.Project.SimpleFactory;
using Ioc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Project
{
    /// <summary>
    /// IOC  Inversion of Control   目地
    /// DI    手段
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    AndroidPhone phone = new AndroidPhone();
                    phone.Call();
                }
                {
                    IPhone phone = new ApplePhone();
                    phone.Call();
                }
                {
                    IPhone phone = ObjectFactory.CreateInstance();
                    phone.Call();
                }

                {
                    //IocTest.Show();
                }
                {

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
