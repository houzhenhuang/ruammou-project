using Homework.Bussiness.Interface;
using Homework.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq.Expressions;

namespace Homework.Bussiness.Service
{
    public class BaseService : IBaseService
    {
        public DbContext DbContext { get; private set; }

        public BaseService(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public void Delete<T>(int id) where T : class
        {
            T t = this.GetData<T>(id);
            this.DbContext.Set<T>().Remove(t);
            this.DbContext.SaveChanges();
        }
        public void Delete<T>(T t) where T : class
        {
            this.DbContext.Set<T>().Remove(t);
            this.DbContext.SaveChanges();
        }

        public void Insert<T>(T t) where T : class
        {
            DbContext.Set<T>().Add(t);
            DbContext.SaveChanges();
        }
        public void InsertList<T>(IEnumerable<T> tList) where T : class
        {
            DbContext.Set<T>().AddRange(tList);
            DbContext.SaveChanges();
        }
        public void Update<T>(T t) where T : class
        {
            this.DbContext.Set<T>().Attach(t);
            this.DbContext.Entry<T>(t).State = EntityState.Modified;
            this.DbContext.SaveChanges();
        }
        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            tList.ToList().ForEach((p) =>
            {
                this.DbContext.Set<T>().Attach(p);
                this.DbContext.Entry<T>(p).State = EntityState.Modified;
            });
            this.DbContext.SaveChanges();
        }

        public T GetData<T>(int id) where T : class
        {
            return DbContext.Set<T>().Find(id);
        }
        public IQueryable<T> QueryList<T>() where T : class
        {
            return this.DbContext.Set<T>();
        }
        public IQueryable<T> QueryList<T>(Expression<Func<T, bool>> where) where T : class
        {
            return this.DbContext.Set<T>().Where(where);
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}
