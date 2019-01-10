using Homework.Web.Core.Filter;
using System.Web;
using System.Web.Mvc;

namespace Homework.Mvc5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeFilter());
        }
    }
}
