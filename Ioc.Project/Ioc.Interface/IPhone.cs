using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Interface
{
    public interface IPhone
    {
        void Call();

        IMicrophone Microphone { get; set; }
        IHeadphone Headphone { get; set; }
        IBluetooth Bluetooth { get; set; }

    }
}
