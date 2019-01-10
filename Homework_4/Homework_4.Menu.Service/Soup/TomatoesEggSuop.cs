using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.Menu.Service.Soup
{
    /// <summary>
    /// 西红柿蛋汤
    /// </summary>
    public class TomatoesEggSuop : ISoup
    {

        public void Show()
        {
            Console.WriteLine("你选择了西红柿蛋汤");
        }
    }
}
