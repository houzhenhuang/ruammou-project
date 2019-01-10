using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstHomework.DB.Interface;
using System.Reflection;
using System.Configuration;

namespace FirstHomework
{
    public class simpleFacetory
    {
        private static string dbType = ConfigurationManager.AppSettings["IDBHelper"];
        private static string dllName = dbType.Split(',')[0];
        private static string typeName = dbType.Split(',')[1];
        public static IDBHelper CreateFacetory() 
        {
            Assembly assembly = Assembly.Load(dllName);
            Type type = assembly.GetType(typeName);
            object oObject = Activator.CreateInstance(type);
            return (IDBHelper)oObject;
        }
    }
}
