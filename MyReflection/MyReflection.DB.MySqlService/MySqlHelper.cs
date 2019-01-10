using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyReflection.DB.Interface;

namespace MyReflection.DB.MySqlService
{

    public class MySqlHelper : IDBHelper
    {
        public void Query()
        {
            Console.WriteLine(  "这里是{0}的Query",this.GetType().FullName);
        }
    }
}
