using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service
{
    /// <summary>
    /// 庐山石鸡
    /// </summary>
    public class LuShanShiJi : IMenuName
    {
        public void Show() 
        {
            Console.WriteLine("这是“庐山石鸡”，吃起来很美味");
        }
    }
}
