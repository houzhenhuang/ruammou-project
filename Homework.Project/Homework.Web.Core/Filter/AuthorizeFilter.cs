using Homework.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Homework.Web.Core.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 未登录指向的地址
        /// </summary>
        private string _LoginPath = "";
        public AuthorizeFilter()
        {
            this._LoginPath = "/Home/Login";
        }
        public AuthorizeFilter(string loginPath)
        {
            this._LoginPath = loginPath;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true)|| filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            var sessionUser = HttpContext.Current.Session["CurrentUser"];
            //var memberValidation = HttpContext.Current.Request.Cookies.Get("CurrentUser");//使用cookie
            if (sessionUser==null||!(sessionUser is CurrentUser))
            {
                HttpContext.Current.Session["CurrentUrl"]=filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(this._LoginPath);
            }
        }
    }
}
