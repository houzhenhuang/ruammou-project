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
    public class SingletonThird
    {
        public static SingletonThird _SingletonThird = new SingletonThird();
        private SingletonThird()
        {
            Console.WriteLine("{0} 被构造", this.GetType());
        }
        public void WriteText()
        {
            Console.WriteLine("这里是单例模式");
        }
        public static SingletonThird CreateInstance()
        {
            return _SingletonThird;
        }
    }
}
