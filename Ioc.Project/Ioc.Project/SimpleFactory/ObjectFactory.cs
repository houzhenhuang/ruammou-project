using Ioc.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Project.SimpleFactory
{
    public class ObjectFactory
    {
        private static string _Obj = ConfigurationManager.AppSettings["IPhone"];
        private static string _TypeString = _Obj.Split(',')[0];
        private static string _DllString = _Obj.Split(',')[1];
        public static IPhone CreateInstance()
        {
            Assembly assembly = Assembly.Load(_DllString);
            Type type = assembly.GetType(_TypeString);
            return (IPhone)Activator.CreateInstance(type);
        }
    }
}
