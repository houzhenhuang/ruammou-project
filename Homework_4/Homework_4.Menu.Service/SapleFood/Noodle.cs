using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service.SapleFood
{
    /// <summary>
    /// 面条
    /// </summary>
    public class Noodle : ISapleFood
    {

        public void Show()
        {
            Console.WriteLine("你选择了面条作为主食");
        }
    }
}
