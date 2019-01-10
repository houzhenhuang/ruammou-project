using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ioc.EF.Model;

namespace Ioc.Bussiness.Service
{
    public abstract class BaseService
    {
        private PerManagerContext _DbContext { get; set; }

        public BaseService(PerManagerContext context)
        {
            this._DbContext = context;
        }
        public T Find<T>(int id) where T : class
        {
            //T t = this._DbContext
           return default(T);
        }

        public void Add<T>(T t) where T : class
        { }

        public void Update<T>(T t) where T : class
        { }

        public void Delete<T>(T t) where T : class
        { }

        public void List<T>(T t) where T : class
        { }

    }
}
