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
    /// 北派
    /// </summary>
    public class NorthGroup : Perform, ICharge
    {
        public NorthGroup() 
        {
            base._MaxTemperature = 1000;
        }
        public override void DogWang()
        {
            throw new NotImplementedException();
        }

        public override void PersonSpeak()
        {
            throw new NotImplementedException();
        }

        public override void WindSound()
        {
            throw new NotImplementedException();
        }
        public override void ConcludingRemarks()
        {
            Console.WriteLine("这是北派复写基类的结束语");
        }

        public void Charge()
        {
            Console.WriteLine("北派收费");
        }
    }
}
