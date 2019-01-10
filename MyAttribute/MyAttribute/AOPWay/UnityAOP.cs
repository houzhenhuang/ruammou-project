using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace MyAttribute.AOPWay
{
    public class UnityAOP
    {
        public static void Show() 
        {
            User user = new User() { Id = 1001, Name = "Jack", Password = "123" };

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserProcessor, UserProcessor>();
            IUserProcessor userProcessor = container.Resolve<IUserProcessor>();
            userProcessor.RegUser(user);


            container.AddNewExtension<Interception>().Configure<Interception>()
                .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());
            IUserProcessor userprocessor = container.Resolve<IUserProcessor>();
            userprocessor.RegUser(user);//调用
        }
         [UserHandlerAttribute(Order = 1)]
        public interface IUserProcessor
        {
            void RegUser(User user);
            User GetUser(User user);
        }
        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。");
            }

            public User GetUser(User user)
            {
                return user;
            }
        }
        public class UserHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                ICallHandler handler = new UserHandler() { Order = this.Order };
                return handler;
            }
        }
        public class UserHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                User user = input.Inputs[0] as User;
                if (user.Password.Length < 10)
                {
                    return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
                }
                Console.WriteLine("参数检测无误");

                IMethodReturn methodReturn = getNext.Invoke().Invoke(input, getNext);

                return methodReturn;
            }
        }


    }
}
