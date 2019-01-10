using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericClass<T>
    {
        public void Show(T t)
        {
            Console.WriteLine(t);
        }
        public T Get(T t) 
        {
            return t;
        }
        public void GenericMethod<W>(W w)
        {}
    }
    public interface IGet<T> 
    {
        
    }

    public delegate void GetHandler<T>();

    public class ChildClass : GenericClass<string> ,IGet<string>
    {
        
    }
    public class ChildClass<T, W> : GenericClass<T>, IGet<W>
    {

    }

}
