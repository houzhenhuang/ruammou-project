﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class StudentVip : AbstractStudent
    {
        public override void Show()
        {
            Console.WriteLine("{0} is a vip student...", base.Name);
        }
    }
}
