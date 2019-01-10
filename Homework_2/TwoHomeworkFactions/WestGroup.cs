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
    /// 西派
    /// </summary>
    public class WestGroup:Perform,ICharge
    {
        public WestGroup() 
        {
            base._MaxTemperature = 400;
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

        public override void OpenWhite()
        {
            Console.WriteLine("这是西派复写基类的开场白");
        }

        public override void ConcludingRemarks()
        {
            Console.WriteLine("这是西派复写基类的结束语");
        }


        public void Charge()
        {
            Console.WriteLine("西派收费");
        }
    }
}
