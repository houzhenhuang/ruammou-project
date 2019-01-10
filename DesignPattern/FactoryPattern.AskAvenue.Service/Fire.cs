using FactoryPattern.AskAvenue.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.AskAvenue.Service
{
    /// <summary>
    /// 火系
    /// </summary>
    public class Fire : IFactions
    {
        public void Show()
        {
            Console.WriteLine("this is {0} Factions", this.GetType());
        }
    }
}
