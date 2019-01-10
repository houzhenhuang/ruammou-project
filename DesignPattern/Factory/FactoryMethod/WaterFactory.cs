using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public class WaterFactory : IFactoryMethod
    {
        public IFactions CreateInstance()
        {
            return new Water();
        }
    }
}
