using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Abstract
{
    public class AWoodFactory : AbstractFactory
    {

        public override IAuxiliarySkill CreateAuxiliarySkill()
        {
            return new WoodAuxiliarySkill();
        }

        public override IObstacleSkill CreateObstacleSkill()
        {
            return new WoodObstacleSkill();
        }

        public override IMagicAttackSkill CreateMagicAttackSkill()
        {
            return new WoodMagicAttackSkill();
        }
    }
}
