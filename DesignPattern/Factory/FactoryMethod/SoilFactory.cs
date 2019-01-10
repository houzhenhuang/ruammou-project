﻿using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public class SoilFactory : IFactoryMethod
    {
        public  IFactions CreateInstance()
        {
            return new Soil();
        }
    }
}
