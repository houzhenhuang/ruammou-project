using FactoryPattern.AskAvenue.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.AskAvenue.Service
{
    /// <summary>
    /// 木系
    /// </summary>
    public class Wood : IFactions
    {
        public void Show()
        {
            Console.WriteLine("this is {0} Factions", this.GetType());
        }
    }
    public class WoodAuxiliarySkill : IAuxiliarySkill
    {
        public void ShowAllSkill()
        {
            Console.WriteLine("拔苗助长，火上浇油，水涨船高，红花绿叶，锦上添花");
        }
    }
    /// <summary>
    /// 障碍技能
    /// </summary>
    public class WoodObstacleSkill : IObstacleSkill
    {
        public void ShowAllSkill()
        {
            Console.WriteLine("见血封喉，蛇口蜂针，鹤顶红粉，蝎尾蛇涎，万蚁噬心");
        }
    }
    /// <summary>
    /// 法攻技能
    /// </summary>
    public class WoodMagicAttackSkill : IMagicAttackSkill
    {
        public void ShowAllSkill()
        {
            Console.WriteLine("摘叶飞花，飞柳仙矢，盘根错节，落英缤纷，鬼舞枯藤	");
        }
    }
}
