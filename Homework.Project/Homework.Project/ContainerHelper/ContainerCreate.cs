using Homework.Bussiness.Interface;
using Homework.Bussiness.Service;
using Homework.EF.Model;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Project.ContainerHelper
{
    public class ContainerCreate
    {
        private static IUnityContainer _Container = null;
        private static readonly object obj = new object();
        public static ContainerCreate _ContainerCreate = null;
        private ContainerCreate()
        {
            //{
            //    _Container = new UnityContainer();
            //    _Container.RegisterType<IBaseService,BaseService>();
            //    _Container.RegisterType<IUserMenuService, UserMenuService>(new InjectionConstructor(typeof(DbContext),123));
            //    _Container.RegisterType<DbContext,HomeworkContext>();

            //    _Container.AddNewExtension<Interception>().Configure<Interception>()
            //        .SetInterceptorFor<IUserMenuService>(new InterfaceInterceptor());
            //}
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                _Container = new UnityContainer();
                section.Configure(_Container, "configContainer");
            }
        }

        public static ContainerCreate CreateInstance()
        {
            if (_ContainerCreate == null)
            {
                lock (obj)
                {
                    if (_ContainerCreate == null)
                    {
                        _ContainerCreate = new ContainerCreate();
                    }
                }
            }
            return _ContainerCreate;
        }

        public IUnityContainer GetContainer() => _Container;

    }
}
