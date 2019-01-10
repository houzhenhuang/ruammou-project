using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式(懒汉模式，用的时候才调用)
    /// </summary>
    public class Singleton
    {
        public static Singleton _singleton = null;
        public static object obj_Singleton = new object();
        private Singleton()
        {
            Console.WriteLine("{0} 被构造", this.GetType());
        }

        public void WriteText()
        {
            Console.WriteLine("这里是单例模式");
        }

        public static Singleton CreateInstance()
        {
            if (_singleton == null)
            {
                lock (obj_Singleton)
                {
                    if (_singleton == null)
                    {
                        _singleton = new Singleton();
                    }
                }
            }
            return _singleton;
        }



    }
}
