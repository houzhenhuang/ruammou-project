using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection.DB.SqlService
{
    public class GenericClass<T,W,X>
    {
        public void Show(T t,W w,X x) 
        {
            Console.WriteLine("t.Type={0},w.Type={1},x.Type={2}", t.GetType(), w.GetType(), x.GetType());
        }
    }

    public class GenericMethod
    {
        public void Show<T, W, X>(T t, W w, X x)
        {
            Console.WriteLine("t.Type={0},w.Type={1},x.Type={2}", t.GetType(), w.GetType(), x.GetType());
        }
    }

    public class GenericDouble<T>
    {
        public void Show<W, X>(T t, W w, X x)
        {
            Console.WriteLine("t.Type={0},w.Type={1},x.Type={2}", t.GetType(), w.GetType(), x.GetType());
        }
    }
}
