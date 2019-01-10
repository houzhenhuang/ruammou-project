using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework.Web.Core.IOC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private IUnityContainer Unitycontainer { get => DIFactory.GetContainer(); }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            IController controller = Unitycontainer.Resolve(controllerType) as IController;
            return controller;
        }
        public override void ReleaseController(IController controller)
        {
            this.Unitycontainer.Teardown(controller);//通过容器运行现有的对象，并清理它。（释放）
        }
    }
}
