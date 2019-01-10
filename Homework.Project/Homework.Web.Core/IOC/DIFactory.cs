using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Web.Core.IOC
{
    /// <summary>
    /// 依赖注入工厂
    /// </summary>
    public class DIFactory
    {
        private static object _obj = new object();
        private static Dictionary<string, IUnityContainer> _UnityContainerDictionary = new Dictionary<string, IUnityContainer>();
        public static IUnityContainer GetContainer(string containerName = "homeworkContainer")
        {
            if (!_UnityContainerDictionary.ContainsKey(containerName))
            {
                lock (_obj)
                {
                    if (!_UnityContainerDictionary.ContainsKey(containerName))
                    {
                        IUnityContainer container = new UnityContainer();

                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找配置文件的路径
                        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                        section.Configure(container, containerName);

                        _UnityContainerDictionary.Add(containerName, container);
                    }
                }
            }
            return _UnityContainerDictionary[containerName];
        }
    }
}
