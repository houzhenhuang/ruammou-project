using Homework_3.Common;
using System;

namespace Homework_3
{
    public class CommonLog
    {
        private static object obj = new object();
        public static void WriteLogText(string msg)
        {
            Console.WriteLine(msg);
            lock (obj)
            {
                LogHelper.WriteLog(msg);
            }             
        }
    }
}
