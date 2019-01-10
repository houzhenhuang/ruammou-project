using Homework.Bussiness.Interface;
using Homework.EF.Model;
using Homework.Framework.Extension;
using Homework.Framework.ImageHelper;
using Homework.Framework.Log;
using Homework.Framework.Models;
using Homework.Mvc5.Utility;
using Homework.Remote.Interface;
using Homework.Remote.Model;
using Homework.Web.Core.IOC;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Mvc5.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {      
        private IUserMenuService service = null;
        private ISearch iCommoditySearch = null;
        public HomeController(IUserMenuService userMenuService, ISearch search)
        {
            this.service = userMenuService;
            this.iCommoditySearch = search;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public string TestIOC()
        {
            {
                //IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
                //return service.GetData<User>(2).Name;
            }
            {
                return service.GetData<User>(2).Name;
            }
        }

        public void LuceneSearch()
        {
            List<int> categoryIdList = new List<int>() { 1656 };//9987,653,655

            PageResult<CommodityModel> result = iCommoditySearch.QueryCommodityPage(1, 10, "男装", categoryIdList, null, null);

        }
        public FileResult VerifyCode()
        {
            string code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["VerfyCode"] = code;
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password, string verify)
        {
            UserManage.LoginResult loginResult = this.HttpContext.UserLogin(name, password, verify);
            if (loginResult == UserManage.LoginResult.Success)
            {
                if (this.HttpContext.Session["CurrentUrl"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string url = this.HttpContext.Session["CurrentUrl"].ToString();
                    this.HttpContext.Session["CurrentUrl"] = null;
                    return Redirect(url);
                }
            }
            else
            {
                ModelState.AddModelError("failed", loginResult.GetRemark());
                return View();
            }
        }
    }
}
