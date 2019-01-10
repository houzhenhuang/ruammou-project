using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    public static class Extend
    {
        public static string TableName<T>(this T t)
            where T : class,new()
        {
            Type type = t.GetType();
            object[] objAttr = type.GetCustomAttributes(true);
            foreach (var item in objAttr)
            {
                if (item is TableAttribute)
                {
                    return ((TableAttribute)item).GetTableName();
                }
            }
            return type.Name;
        }
    }
}
