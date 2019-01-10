using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.SimpleFactory
{
    public class ObjectFactory
    {
        public static IFactions CreateInstance(FactionsType type)
        {
            IFactions iFactions = null;
            switch (type)
            {
                case FactionsType.Gold: iFactions = new Gold();
                    break;
                case FactionsType.Wood: iFactions = new Wood();
                    break;
                case FactionsType.Water: iFactions = new Water();
                    break;
                case FactionsType.Fire: iFactions = new Fire();
                    break;
                case FactionsType.Soil: iFactions = new Soil();
                    break;
                default:
                    throw new Exception("wrong FactionsType");
            }
            return iFactions;
        }
        public enum FactionsType
        {
            Gold = 1,
            Wood = 2,
            Water = 3,
            Fire = 4,
            Soil = 5
        }
    }
}

