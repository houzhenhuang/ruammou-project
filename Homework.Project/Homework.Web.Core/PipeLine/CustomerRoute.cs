using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework.Web.Core.PipeLine
{
    public class CustomerRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {          
            if (HttpContext.Current.Request.UserAgent.IndexOf("Firefox") >= 0)
            {
                RouteData routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "Brower");
                return routeData;
            }
            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
