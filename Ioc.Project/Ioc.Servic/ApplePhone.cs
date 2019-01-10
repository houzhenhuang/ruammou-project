using Ioc.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Service
{
    public class ApplePhone : IPhone
    {
        public ApplePhone()
        {
            Console.WriteLine("{0}构造函数", this.GetType().Name);
        }
        [InjectionConstructor]
        public ApplePhone(IMicrophone microphone)
        {
            this.Microphone = microphone;
        }
        public void Call()
        {
            Console.WriteLine("{0}在打电话!", typeof(ApplePhone).Name);
        }

        public IMicrophone Microphone { get; set; }

        public IHeadphone Headphone { get; set; }
        [Dependency]
        public IBluetooth Bluetooth { get; set; }

        [InjectionMethod]
        public void InitMethod(IHeadphone headphone)
        {
            this.Headphone = headphone;
        }
    }
}
