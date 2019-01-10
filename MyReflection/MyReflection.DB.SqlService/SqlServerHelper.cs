using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyReflection.DB.Interface;
using System.Configuration;

namespace MyReflection.DB.SqlService
{
    public class SqlServerHelper : IDBHelper
    {
        //private static string connectionStringCustomers = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;
        public SqlServerHelper() 
        {
            Console.WriteLine("{0}被构造",this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("这里是{0}的Query", this.GetType().FullName);
        }
        public void Add()
        {
            Console.WriteLine("这里是{0}的Add", this.GetType().FullName);
        }
        public T Get<T>(int id)
        {
            string sqlStr = "";
            return default(T);
        }

    }
}
