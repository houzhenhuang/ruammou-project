using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    /// <summary>
    /// 这里是注释，除了让人看懂这里写的是什么，对运行和编译没有任何的影响
    /// </summary>
    //[Obsolete("这个类已经过时了，请不要使用了")]
    public class People
    {
         [Obsolete("这个属性已经过时了，请不要使用了")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
