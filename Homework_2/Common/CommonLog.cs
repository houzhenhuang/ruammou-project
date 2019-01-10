using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonLog
    {
        public static void WriteLogText(string msg)
        {
            Console.WriteLine(msg);
            LogHelper.WriteLog(msg);
        }
    }
}
