using Homework_4.IMenu;
using Homework_4.Menu.Service;
using Homework_4.Menu.Service.SapleFood;
using Homework_4.Menu.Service.Soup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    /// <summary>
    /// 湘菜工厂
    /// </summary>
    public class AHunanCuisineFactory : AbstractFactory
    {

        public override IMenuName CreateMenu_1()
        {
            return new SiXingWangYue();
        }
        public override IMenuName CreateMenu_2()
        {
            return new LiHaoChaoLaRou();
        }
        public override IMenuName CreateMenu_3()
        {
            return new PoHuPangYuTou();
        }
        public override ISapleFood CreateSapleFood()
        {
            return new SteamedRice();
        }
        public override ISoup CreateSoup()
        {
            return new LaverEggSuop();
        }
    }
}
