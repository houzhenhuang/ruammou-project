using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [Custom()]
    [Custom(123)]
    [Custom("456")]
    [Custom(123,"456")]
    [Custom(123, "456",Remark="这里是特性")]
    public class Student
    {
    }
}
