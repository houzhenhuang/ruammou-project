using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Homework.Unity;

namespace Homework.Bussiness.Interface
{
    //[LoggerAttribute]
    public interface IBaseService : IDisposable
    {

        void Insert<T>(T t) where T : class;

        void InsertList<T>(IEnumerable<T> tList) where T : class;

        void Update<T>(T t) where T : class;

        void Update<T>(IEnumerable<T> tList) where T : class;

        void Delete<T>(int id) where T : class;

        void Delete<T>(T t) where T : class;

        T GetData<T>(int id) where T : class;

        IQueryable<T> QueryList<T>() where T : class;

        IQueryable<T> QueryList<T>(Expression<Func<T, bool>> where) where T : class;


    }
}
