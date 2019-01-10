using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3.Model
{
    [Serializable]  //必须添加序列化特性
    public class NovelLead
    {
        public string Name { get; set; }
        public string Story { get; set; }
        public int FontColor { get; set; }
    }
}
