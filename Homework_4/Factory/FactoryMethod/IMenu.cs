using Homework_4.IMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.FactoryMethod
{
    public interface IMenu
    {
        IMenuName CreateInstance();
    }
}
