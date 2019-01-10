using Ioc.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Service
{
    public class AndroidPhone : IPhone
    {

        public void Call()
        {
            Console.WriteLine("{0}在打电话!", typeof(AndroidPhone).Name);
        }

        public IMicrophone Microphone { get; set; }

        public IHeadphone Headphone { get; set; }

        public IBluetooth Bluetooth { get; set; }
    }
}
