using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Unity
{
    public class LoggerBehavior : IInterceptionBehavior
    {

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBehavior");
            return getNext().Invoke(input, getNext);
        }
        public bool WillExecute
        {
            get { return true; }
        }
    }

    public class LoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler callHandler = new CallHandler();
            return callHandler;
        }
    }
    public class CallHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("LoggerAttribute");
            return getNext()(input,getNext);
        }
    }
}
