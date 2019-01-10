using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using TwoHomeworkFactions;
using TwoHomeworkAbstract.Abstract;
using TwoHomeworkAbstract.Interface;

namespace TwoHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region work_1
                {
                    //EastGroup eastGroup = new EastGroup();
                    //eastGroup.OnePerson = "我是东方人";
                    //eastGroup.OneTable = "东方八仙桌";
                    //eastGroup.OneChari = "东方八仙椅";
                    //eastGroup.OneFan = "东方芭蕉扇";
                    //eastGroup.OneRuler = "东方八仙尺";
                    //Show<EastGroup>(eastGroup);
                }
                {
                    //SouthGroup southGroup = new SouthGroup();
                    //southGroup.OnePerson = "我是南方人";
                    //southGroup.OneTable = "南方八仙桌";
                    //southGroup.OneChari = "南方八仙椅";
                    //southGroup.OneFan = "南方芭蕉扇";
                    //southGroup.OneRuler = "南方八仙尺";
                    //Show<SouthGroup>(southGroup);
                }
                #endregion

                {
                    //SetTemperature(600);

                    EastGroup eastGroup = new EastGroup();
                    eastGroup.fireEvent += () => Console.WriteLine("东派的人：夫起大呼，妇亦起大呼。两儿齐哭。俄而百千人大呼，百千儿哭，百千犬吠。");
                    eastGroup._Temperature = 400;

                }

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Show<T>(T t)
            where T : Perform, ICharge
        {
            Console.WriteLine(String.Join(",",
                t.GetType().GetProperties().Select(p => String.Format("{0}={1}", p.Name, p.GetValue(t)))));
            t.PerformStart();
            t.OpenWhite();
            t.DogWang();
            t.PersonSpeak();
            t.WindSound();
            t.ConcludingRemarks();
            t.Charge();
        }
    }
}
