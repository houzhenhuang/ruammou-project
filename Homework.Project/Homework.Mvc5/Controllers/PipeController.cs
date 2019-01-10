using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Mvc5.Controllers
{
    [AllowAnonymous]
    public class PipeController : Controller
    {
        // GET: Pipe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowModules()
        {
            HttpModuleCollection moduls = base.HttpContext.ApplicationInstance.Modules;
            //List<>
            return View(moduls);
        }
        public ActionResult ShowEvents()
        {
            System.Reflection.EventInfo[] events = base.HttpContext.ApplicationInstance.GetType().GetEvents();
            //List<>
            return View(events);
        }
    }
}