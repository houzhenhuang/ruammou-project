using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.OrderSystem.AbstractHelper
{
    public abstract class AbstractFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Desc { get; set; }
        /// <summary>
        /// 品尝方法
        /// </summary>
        public void Taste()
        {
            Console.WriteLine("正在品尝{0}", this.Name);
        }
        /// <summary>
        /// 点评虚方法
        /// </summary>
        public virtual void Comment()
        {
            Random randmo = new Random();
            double n = randmo.Next(1, 11);
            Console.WriteLine("点评分数:{0}", n);
        }

        /// <summary>
        /// 做菜抽象方法
        /// </summary>
        public abstract void DoFood();
    }
}
