using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection.DB.SqlService
{
    public class ReflectionTest
    {
        #region Identity
        
        #endregion
        public void show1() 
        {
            Console.WriteLine("这里是{0}的show1", this.GetType());
        }
        public void show2(int id)
        {
            Console.WriteLine("这里是{0}的show2", this.GetType());
        }
        public void show3()
        {
            Console.WriteLine("这里是{0}无参的show3", this.GetType());
        }
        public void show3(string name,int id)
        {
            Console.WriteLine("这里是{0}带string参数和int参数的show3", this.GetType());
        }
        public void show3(int id,string name)
        {
            Console.WriteLine("这里是{0}带int参数和string参数的show3", this.GetType());
        }
        public void show3(int id)
        {
            Console.WriteLine("这里是{0}带int参数的show3", this.GetType());
        }
        public void show3(string name)
        {
            Console.WriteLine("这里是{0}带string参数的show3", this.GetType());
        }

        private void show4(string name)
        {
            Console.WriteLine("这里是{0}的show4", this.GetType());
        }

        public static void show5(string name)
        {
            Console.WriteLine("这里是{0}的show5", typeof(ReflectionTest));
        }
    }
}
