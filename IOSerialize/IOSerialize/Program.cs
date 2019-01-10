using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using IOSerialize.IO;

namespace IOSerialize
{
    /// <summary>
    /// 1.文件夹/文件    检查、新增、复制、移动、删除
    /// 2.文件读写，记录文本日志/读取配置文本
    /// 3、try catch的正确姿势(连接:http://pan.baidu.com/s/lkVNorpd 密码:pyhv)
    /// 4、递归的编程技巧
    /// 5、xml和json
    /// 6、作业部署
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyIO.Show();

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
