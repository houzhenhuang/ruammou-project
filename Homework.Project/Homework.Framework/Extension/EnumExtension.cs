using Homework.Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Framework.Extension
{
    public static class EnumExtension
    {
        private static Logger logger = Logger.CreateLogger(typeof(EnumExtension));
        /// <summary>
        /// 获取当前枚举值的Remark
        /// </summary>
        /// <param name="eValue"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum eValue)
        {
            string remark = string.Empty;
            Type type = eValue.GetType();
            FieldInfo fieldInfo = type.GetField(eValue.ToString());

            try
            {
                object[] attris = fieldInfo.GetCustomAttributes(type, false);
                RemarkAttribute attr = (RemarkAttribute)attris.FirstOrDefault(a => a is RemarkAttribute);
                if (attr == null)
                {
                    return attr.Remark;
                }
                else
                {
                    remark = attr.Remark;
                }
            }
            catch (Exception ex)
            {
                logger.Error("EnumExtension的GetRemark出现异常", ex);
            }
            return remark;
        }
        /// <summary>
        /// 获取当前枚举的全部Remark
        /// </summary>
        /// <param name="eValue"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetAllRemark(this Enum eValue)
        {
            List<KeyValuePair<string, string>> remarkList = new List<KeyValuePair<string, string>>();
            Type type = eValue.GetType();
            foreach (var field in type.GetFields())
            {
                if (field.FieldType.IsEnum)
                {
                    object tempValue = field.GetValue(eValue);
                    Enum enumValue = (Enum)tempValue;
                    int iValue = (int)tempValue;
                    remarkList.Add(new KeyValuePair<string, string>(iValue.ToString(), enumValue.GetRemark()));
                }
            }
            return remarkList;
        }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RemarkAttribute : Attribute
    {
        private string _remark = string.Empty;
        public RemarkAttribute(string remark)
        {
            this._remark = remark;
        }
        public string Remark { get => this._remark; set => this._remark = value; }

        public string Description { get; set; }
    }
}
