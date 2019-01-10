using FactoryPattern.AskAvenue.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.AskAvenue.Service
{
    /// <summary>
    /// 金系
    /// </summary>
    public class Gold : IFactions
    {
        public void Show()
        {
            Console.WriteLine("this is {0} Factions", this.GetType());
        }
    }
    /// <summary>
    /// 辅助技能
    /// </summary>
    public class GoldAuxiliarySkill : IAuxiliarySkill
    {       
        public void ShowAllSkill()
        {
            Console.WriteLine("天生神力，气冲斗牛，九牛二虎，如虎添翼，力挽狂澜");
        }
    }
    /// <summary>
    /// 障碍技能
    /// </summary>
    public class GoldObstacleSkill : IObstacleSkill
    {
        public void ShowAllSkill()
        {
            Console.WriteLine("流连忘返，得意忘形，如梦初醒，如痴如醉，恍若隔世");
        }
    }
    /// <summary>
    /// 法攻技能
    /// </summary>
    public class GoldMagicAttackSkill : IMagicAttackSkill
    {
        public void ShowAllSkill()
        {
            Console.WriteLine("金光乍现，刀光剑影，金虹贯日，流光异彩，逆天残刃");
        }
    }
}
