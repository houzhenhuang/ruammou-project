using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Web.Core.PipeLine
{
    public class BaseModule : IHttpModule
    {
        public void Dispose()
        {
           
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;

            application.Context.Response.Write(string.Format("<hr><hr><h1 style='color:#f00'>来自BaseModule  BeginRequest的处理，{0}请求到达</h1> ", DateTime.Now));
        }
        private void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;

            application.Context.Response.Write(string.Format("<h1 style='color:#00f'>来自BaseModule  EndRequest的处理，{0}请求到达</h1> ", DateTime.Now));
        }
    }
}
