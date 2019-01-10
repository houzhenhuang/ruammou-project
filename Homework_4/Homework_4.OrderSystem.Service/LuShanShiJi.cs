using Homework_4.OrderSystem.AbstractHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4.OrderSystem.Service
{
    /// <summary>
    /// 庐山石鸡
    /// </summary>
    public class LuShanShiJi : AbstractFood
    {
        public override void DoFood()
        {
            Console.WriteLine("正在做“庐山石鸡”菜。。。");
        }
    }
}
