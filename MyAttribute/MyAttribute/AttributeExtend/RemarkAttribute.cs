using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RemarkAttribute : Attribute
    {
        private string _remark = null;
        public RemarkAttribute(string remark)
        {
            this._remark = remark;
        }
        public string Remark
        {
            get
            {
                return this._remark;
            }
        }
    }

    public static class EnumRemarkExtend
    {
        public static string GetRemark(this Enum e)
        {
            Type type=e.GetType();
            FieldInfo fieldInfo= type.GetField(e.ToString());
            RemarkAttribute remarkAttr=(RemarkAttribute)fieldInfo.GetCustomAttribute(typeof(RemarkAttribute));

            return remarkAttr.Remark;
        }
    }
}
