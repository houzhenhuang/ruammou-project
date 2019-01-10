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
    /// 庐山石鸡工厂
    /// </summary>
    public class LuShanShiJiFactory : IMenu
    {
        public IMenuName CreateInstance()
        {
            return new LuShanShiJi();
        }
    }
}
