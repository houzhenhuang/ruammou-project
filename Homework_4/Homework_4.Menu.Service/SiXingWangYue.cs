using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service
{
    /// <summary>
    /// 四星望月
    /// </summary>
    public class SiXingWangYue : IMenuName
    {
        public void Show() 
        {
            Console.WriteLine("这是“四星望月”，吃起来很美味");
        }
    }
}
