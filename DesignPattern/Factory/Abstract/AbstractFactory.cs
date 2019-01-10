using FactoryPattern.AskAvenue.Interface;
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
        /// 创建辅助技能
        /// </summary>
        /// <returns></returns>
        public abstract IAuxiliarySkill CreateAuxiliarySkill();
        /// <summary>
        /// 创建障碍技能
        /// </summary>
        /// <returns></returns>
        public abstract IObstacleSkill CreateObstacleSkill();
        /// <summary>
        /// 创建法攻技能
        /// </summary>
        /// <returns></returns>
        public abstract IMagicAttackSkill CreateMagicAttackSkill();
    }
}
