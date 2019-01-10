using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Framework.AOP.Behavior
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
}
