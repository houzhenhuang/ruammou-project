using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service.SapleFood
{
    /// <summary>
    /// 馒头
    /// </summary>
    public class SteamedBuns : ISapleFood
    {
        public void Show()
        {
            Console.WriteLine("你选择了馒头作为主食");
        }
    }
}
