using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    public abstract class AbstractFactory
    {
        /// <summary>
        /// 创建菜对象
        /// </summary>
        /// <returns></returns>
        public abstract IMenuName CreateMenu_1();
        /// <summary>
        /// 创建菜对象
        /// </summary>
        /// <returns></returns>
        public abstract IMenuName CreateMenu_2();
        /// <summary>
        /// 创建菜对象
        /// </summary>
        /// <returns></returns>
        public abstract IMenuName CreateMenu_3();
        /// <summary>
        /// 创建主食对象
        /// </summary>
        /// <returns></returns>
        public abstract ISapleFood CreateSapleFood();
        /// <summary>
        /// 创建汤对象
        /// </summary>
        /// <returns></returns>
        public abstract ISoup CreateSoup();
    }
}
