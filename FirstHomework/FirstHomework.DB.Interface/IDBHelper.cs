using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstHomework.Model;
using System.Linq.Expressions;

namespace FirstHomework.DB.Interface
{
    public interface IDBHelper
    {
        IEnumerable<T> QueryList<T>() where T : BaseModel;
        IEnumerable<T> QueryList<T>(Expression<Func<T, bool>> predicate) where T : BaseModel;
        T GetModel<T>(int id) where T : BaseModel;
        bool Insert<T>(T t) where T : BaseModel;
        bool Update<T>(T t) where T : BaseModel;
        bool Delete<T>(int id) where T : BaseModel;
    }
}
