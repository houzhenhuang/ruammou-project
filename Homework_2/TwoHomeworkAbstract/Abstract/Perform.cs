using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoHomeworkAbstract.Abstract
{
    /// <summary>
    /// 口技表演抽象类
    /// </summary>
    public abstract class Perform
    {
        public event Action fireEvent = null;

        /// <summary>
        /// 温度
        /// </summary>
        public int _Temperature;

        /// <summary>
        /// 燃点
        /// </summary>
        protected int _MaxTemperature;

        public int Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                if (_Temperature >= _MaxTemperature)
                {
                    if (fireEvent != null)
                    {
                        fireEvent.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// 一人
        /// </summary>
        public string OnePerson { get; set; }
        /// <summary>
        /// 一桌
        /// </summary>
        public string OneTable { get; set; }
        /// <summary>
        /// 一椅
        /// </summary>
        public string OneChari { get; set; }
        /// <summary>
        /// 一扇
        /// </summary>
        public string OneFan { get; set; }
        /// <summary>
        /// 一抚尺
        /// </summary>
        public string OneRuler { get; set; }

        public void PerformStart()
        {
            Console.WriteLine("表演开始了");
        }
        public abstract void DogWang();//狗叫
        public abstract void PersonSpeak();//人说话
        public abstract void WindSound();//风声
        public virtual void OpenWhite()
        {
            Console.WriteLine("开场白");
        }
        public virtual void ConcludingRemarks()
        {
            Console.WriteLine("结束语");
        }

        public static void Fire()
        {
            Console.WriteLine("火起!");

        }
    }
}
