using Homework_4.IMenu;
using Homework_4.Menu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    /// <summary>
    /// 鄱湖胖鱼头工厂
    /// </summary>
    public class PoHuPangYuTouFactory:IMenu
    {
        public IMenuName CreateInstance()
        {
            return new PoHuPangYuTou();
        }
    }
}
