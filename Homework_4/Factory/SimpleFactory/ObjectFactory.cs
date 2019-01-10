using Homework_4.IMenu;
using Homework_4.Menu.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Factory.SimpleFactory
{
    public class ObjectFactory
    {
        private static string iMenuConfig = ConfigurationManager.AppSettings["IMenuName"];
        private static string dllName = iMenuConfig.Split(',')[0];
        private static string typeName = iMenuConfig.Split(',')[1];

        public static IMenuName CreateInstance(MenuType menuType)
        {
            IMenuName menuName = null;
            switch (menuType)
            {
                case MenuType.PoHuPangYuTou: menuName = new PoHuPangYuTou();
                    break;
                case MenuType.LuShanShiJi: menuName = new LuShanShiJi();
                    break;
                case MenuType.SiXingWangYue: menuName = new SiXingWangYue();
                    break;
                case MenuType.LiHaoChaoLaRou: menuName = new LiHaoChaoLaRou();
                    break;
                default: throw new Exception("wrong: MenuType Error");
            }
            return menuName;
        }

        public static IMenuName CreateInstance()
        {
            Assembly assembly = Assembly.Load(dllName);
            Type type = assembly.GetType(typeName);
            return (IMenuName)Activator.CreateInstance(type);
        }
    }
    public enum MenuType
    {
        /// <summary>
        /// 鄱湖胖鱼头
        /// </summary>
        PoHuPangYuTou = 1,
        /// <summary>
        /// 庐山石鸡
        /// </summary>
        LuShanShiJi = 2,
        /// <summary>
        /// 四星望月
        /// </summary>
        SiXingWangYue = 3,
        /// <summary>
        /// 藜蒿炒腊肉
        /// </summary>
        LiHaoChaoLaRou = 4
    }
}
