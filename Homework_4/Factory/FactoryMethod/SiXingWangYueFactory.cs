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
    /// 四星望月工厂
    /// </summary>
    public class SiXingWangYueFactory : IMenu
    {
        public IMenuName CreateInstance()
        {
            return new SiXingWangYue();
        }
    }
}
