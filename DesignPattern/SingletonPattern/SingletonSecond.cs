using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式(饿汉模式，程序一启动就调用)
    /// </summary>
    public class SingletonSecond
    {
        public static SingletonSecond _SingletonSecond = null;
        private SingletonSecond()
        {
            Console.WriteLine("{0} 被构造", this.GetType());
        }

        public void WriteText()
        {
            Console.WriteLine("这里是单例模式");
        }
        static SingletonSecond()
        {
            _SingletonSecond = new SingletonSecond();
        }

        public static SingletonSecond CreateInstance()
        {
            return _SingletonSecond;
        }



    }
}
