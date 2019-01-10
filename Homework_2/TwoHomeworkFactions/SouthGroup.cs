using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoHomeworkAbstract.Abstract;
using TwoHomeworkAbstract.Interface;

namespace TwoHomeworkFactions
{
    /// <summary>
    /// 南派
    /// </summary>
    public class SouthGroup : Perform, ICharge
    {
        public SouthGroup() 
        {
            base._MaxTemperature = 800;
        }
        public override void DogWang()
        {
            Console.WriteLine("南派狗在叫");
        }

        public override void PersonSpeak()
        {
            Console.WriteLine("南派人在讲话");
        }

        public override void WindSound()
        {
            Console.WriteLine("南风在刮");
        }

        public override void OpenWhite()
        {
            Console.WriteLine("这是南派复写基类的开场白");
        }

        public void Charge()
        {
            Console.WriteLine("南派收费");
        }
    }
}
