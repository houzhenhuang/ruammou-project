using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    public class CommonEnum
    {
        public enum UserState 
        {
            /// <summary>
            /// 正常
            /// </summary>
            [Remark("正常")]
            Normal = 0,
            /// <summary>
            /// 冻结
            /// </summary>
            [Remark("冻结")]
            Frozen = 1,
            /// <summary>
            /// 删除
            /// </summary>
            [Remark("删除")]
            Delete = 2
        }
    }
}
