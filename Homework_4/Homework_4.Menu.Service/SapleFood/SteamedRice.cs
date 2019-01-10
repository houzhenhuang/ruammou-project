using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service.SapleFood
{
    /// <summary>
    /// 米饭
    /// </summary>
    public class SteamedRice : ISapleFood
    {

        public void Show()
        {
            Console.WriteLine("你选择了米饭作为主食");
        }
    }
}
