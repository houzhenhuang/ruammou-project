using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstHomework.DB.Interface;
using System.Reflection;

namespace FirstHomework.DB.MySqlService
{
    public class MySqlHelper : IDBHelper
    {
        public IEnumerable<T> QueryList<T>() where T : Model.BaseModel
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] propertyArray = type.GetProperties();
            string propertyStr = String.Join(",", propertyArray.Select(p => "[" + p.Name + "]"));

            for (int i = 0; i < 1; i++)
            {
                object oObj = Activator.CreateInstance(type);
                foreach (PropertyInfo item in propertyArray)
                {
                    if (item.Name.Equals("Id"))
                    {
                        item.SetValue(oObj, i);
                    }
                    if (item.Name.Equals("Name"))
                    {
                        item.SetValue(oObj, "This is MySql QueryList");
                    }
                }
                list.Add((T)oObj);
            }
            return list;
        }

        public T GetModel<T>(int id) where T : Model.BaseModel
        {
            Type type = typeof(T);
            PropertyInfo[] propertyArray = type.GetProperties();

            object oObj = Activator.CreateInstance(type);
            foreach (PropertyInfo item in propertyArray)
            {
                if (item.Name.Equals("Id"))
                {
                    item.SetValue(oObj, 1001);
                }
                if (item.Name.Equals("Name"))
                {
                    item.SetValue(oObj, "This is MySql GetModel");
                }
                return (T)oObj;
            }
            return default(T);
        }


        public bool Insert<T>(T t) where T : Model.BaseModel
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T t) where T : Model.BaseModel
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(int id) where T : Model.BaseModel
        {
            throw new NotImplementedException();
        }


        public IEnumerable<T> QueryList<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : Model.BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
