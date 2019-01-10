using FactoryPattern.AskAvenue.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public interface IFactoryMethod
    {
        IFactions CreateInstance();
    }
}
