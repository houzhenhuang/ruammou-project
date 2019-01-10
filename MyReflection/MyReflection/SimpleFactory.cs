using MyReflection.DB.Interface;
using MyReflection.DB.OracleService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    public class SimpleFactory
    {
        public static string typeDll = ConfigurationManager.AppSettings["DBHelper"];
        public static string typeName = typeDll.Split(',')[0];
        public static string dllName = typeDll.Split(',')[1];
        public static IDBHelper CreateDBHelper() 
        {
            Assembly assembly = Assembly.Load(dllName);//1.动态加载dll
            Type typeHelper = assembly.GetType(typeName);//2.获取类型信息
            object objDbHelper = Activator.CreateInstance(typeHelper);//3.创建对象
            IDBHelper dbHelper = (IDBHelper)objDbHelper;
            return dbHelper;
        }
    }
}
