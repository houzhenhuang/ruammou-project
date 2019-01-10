using Ioc.Interface;
using Ioc.Service;
using Ioc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.IO;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;


namespace Ioc.Project
{
    public class IocTest
    {
        public static void Show()
        {
            Console.WriteLine("**************************************");
            {
                ApplePhone applePhone = new ApplePhone();
                Console.WriteLine("applePhone.Headphone==null? {0}", applePhone.Headphone == null);
                Console.WriteLine("applePhone.Microphone==null? {0}", applePhone.Microphone == null);
                Console.WriteLine("applePhone.Bluetooth==null? {0}", applePhone.Bluetooth == null);
            }

            Console.WriteLine("*****************UnityAndroid*********************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, AndroidPhone>();
                //接口--类型    父类-子类  抽象类-子类    
                ////container.RegisterInstance<IPhone>(new AndroidPhone());//实例注册
                IPhone phone = container.Resolve<IPhone>();
                //phone.Call();

                Console.WriteLine("applePhone.Headphone==null? {0}", phone.Headphone == null);
                Console.WriteLine("applePhone.Microphone==null? {0}", phone.Microphone == null);
                Console.WriteLine("applePhone.Bluetooth==null? {0}", phone.Bluetooth == null);
            }

            Console.WriteLine("*****************UnityApple*********************");
            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, ApplePhone>();
                container.RegisterType<IMicrophone, Microphone>();
                container.RegisterType<IHeadphone, Headphone>();
                container.RegisterType<IBluetooth, Bluetooth>();

                IPhone phone = container.Resolve<IPhone>();

                Console.WriteLine("applePhone.Headphone==null? {0}", phone.Headphone == null);
                Console.WriteLine("applePhone.Microphone==null? {0}", phone.Microphone == null);
                Console.WriteLine("applePhone.Bluetooth==null? {0}", phone.Bluetooth == null);
            }
            {
                Console.WriteLine("*****************UnityContainer*********************");

                IUnityContainer container = new UnityContainer();
                // container.RegisterType<IPhone, AndroidPhone>(new TransientLifetimeManager());//瞬态生命周期
                //container.RegisterType<IPhone, AndroidPhone>(new ContainerControlledLifetimeManager());//容器单例
                container.RegisterType<IPhone, AndroidPhone>(new PerThreadLifetimeManager());
                //IPhone iphone1 = null;
                //Action act1 = new Action(() =>
                //{
                //    iphone1 = container.Resolve<IPhone>();
                //});
                //IAsyncResult result1 = act1.BeginInvoke(null, null);
                //IPhone iphone2 = null;
                //Action act2 = new Action(() =>
                //{
                //    iphone2 = container.Resolve<IPhone>();
                //});
                //IAsyncResult result2 = act2.BeginInvoke(null, null);

                //act1.EndInvoke(result1);
                //act2.EndInvoke(result2);

                IPhone iphone1 = container.Resolve<IPhone>();
                IPhone iphone2 = container.Resolve<IPhone>();

                Console.WriteLine(object.ReferenceEquals(iphone1, iphone2));
            }
            Console.WriteLine("*****************UnityContainer*********************");
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config.xml");//找到配置文件路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap,ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(Microsoft.Practices.Unity.Configuration.UnityConfigurationSection.SectionName);


                IUnityContainer container = new UnityContainer();
                section.Configure(container, "configContainer");

                IPhone phone = container.Resolve<IPhone>();
                Console.WriteLine("applePhone.Headphone==null? {0}", phone.Headphone == null);
                Console.WriteLine("applePhone.Microphone==null? {0}", phone.Microphone == null);
                Console.WriteLine("applePhone.Bluetooth==null? {0}", phone.Bluetooth == null);
                phone.Call();
            }

        }
    }
}
