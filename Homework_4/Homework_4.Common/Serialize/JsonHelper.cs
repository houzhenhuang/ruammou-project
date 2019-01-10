using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;//对应程序集：System.Web.Extensions



namespace Homework_4.Common.Serialize
{
    public class JsonHelper
    {
        #region JavaScriptSerializer
        /// <summary>
        /// JavaScriptSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ObjectToJson<T>(T t)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(t);
        }
        /// <summary>
        /// JavaScriptSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T StringToObject<T>(string content)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(content);
        } 
        #endregion

    }
}
