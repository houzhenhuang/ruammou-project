using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstHomework
{
    public static class ExentLinq
    {
        public static IEnumerable<TSource> ExentLinqWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) 
        {
            List<TSource> list = new List<TSource>();
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
