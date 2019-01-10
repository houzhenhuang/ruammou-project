using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service
{
    /// <summary>
    /// 鄱湖胖鱼头
    /// </summary>
    public class PoHuPangYuTou : IMenuName
    {
        public void Show() 
        {
            Console.WriteLine("这是“鄱湖胖鱼头”，吃起来很美味");
        }
    }
}
