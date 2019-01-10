using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_4.IMenu;

namespace Homework_4.Menu.Service
{
    /// <summary>
    /// 藜蒿炒腊肉
    /// </summary>
    public class LiHaoChaoLaRou : IMenuName
    {
        public void Show() 
        {
            Console.WriteLine("这是“藜蒿炒腊肉”，吃起来很美味");
        }
    }
}
