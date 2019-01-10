using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoHomeworkAbstract.Abstract;
using TwoHomeworkAbstract.Interface;

using Common;

namespace TwoHomeworkFactions
{
    /// <summary>
    /// 东派
    /// </summary>
    public class EastGroup : Perform, ICharge
    {
        public EastGroup() 
        {
            base._MaxTemperature = 400;
        }
        public override void DogWang()
        {
            CommonLog.WriteLogText ("东派狗在叫");
        }
        public override void PersonSpeak()
        {
            CommonLog.WriteLogText("东派人在讲话");
        }

        public override void WindSound()
        {
            CommonLog.WriteLogText("东风在刮");
        }
        public void Charge()
        {
            CommonLog.WriteLogText("东派收费");
        }
    }
}
