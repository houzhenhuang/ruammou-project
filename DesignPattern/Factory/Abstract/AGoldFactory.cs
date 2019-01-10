using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    public class AGoldFactory : AbstractFactory
    {

        public override IAuxiliarySkill CreateAuxiliarySkill()
        {
            return new GoldAuxiliarySkill();
        }

        public override IObstacleSkill CreateObstacleSkill()
        {
            return new GoldObstacleSkill();
        }

        public override IMagicAttackSkill CreateMagicAttackSkill()
        {
            return new GoldMagicAttackSkill();
        }
    }
}
