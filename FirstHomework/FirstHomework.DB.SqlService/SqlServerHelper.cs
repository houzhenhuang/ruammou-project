using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstHomework.DB.Interface;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using FirstHomework.Model;
using System.Linq.Expressions;
using ExpressionVisitorCommon;

namespace FirstHomework.DB.SqlService
{
    public class SqlServerHelper : IDBHelper
    {
        private static readonly string connectionStr = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        public IEnumerable<T> QueryList<T>() where T : BaseModel
        {
            List<T> list = new List<T>();
            try
            {
                Type type = typeof(T);
                PropertyInfo[] propertyArray = type.GetProperties();
                string propertyStr = String.Join(",", propertyArray.Select(p => "[" + p.Name + "]"));
                string sqlStr = String.Format("SELECT {0} FROM {1}", propertyStr, "[" + typeof(T).Name + "]");

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    SqlDataReader dr = comd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        var oObj = Activator.CreateInstance(type);
                        foreach (PropertyInfo item in propertyArray)
                        {
                            item.SetValue(oObj, dr[item.Name]);
                        }
                        list.Add((T)oObj);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public IEnumerable<T> QueryList<T>(Expression<Func<T, bool>> predicate) where T : BaseModel
        {
            List<T> list = new List<T>();
            try
            {
                Type type = typeof(T);
                PropertyInfo[] propertyArray = type.GetProperties();
                string propertyStr = string.Join(",", propertyArray.Select(p => string.Format("[" + p.Name + "]")));
                string sqlStr = string.Format("SELECT {0} FROM {1} WHERE 1=1 AND", propertyStr, typeof(T).Name);

                ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
                visitor.Visit(predicate);
                sqlStr += visitor.Condition();//条件

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    SqlDataReader dr = comd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        var oObj = Activator.CreateInstance(type);
                        foreach (PropertyInfo item in propertyArray)
                        {
                            item.SetValue(oObj, dr[item.Name]);
                        }
                        list.Add((T)oObj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
        public T GetModel<T>(int id) where T : BaseModel
        {
            try
            {
                Type type = typeof(T);
                PropertyInfo[] propertyArray = type.GetProperties();
                string propertyStr = String.Join(",", propertyArray.Select(p => "[" + p.Name + "]"));
                string sqlStr = String.Format("SELECT {0} FROM [{1}] WHERE ID=@Id", propertyStr, type.Name);

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    SqlParameter sqlParamter = new SqlParameter("@Id", id);
                    comd.Parameters.Add(sqlParamter);
                    conn.Open();
                    SqlDataReader dr = comd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.Read())
                    {
                        var oObj = Activator.CreateInstance(type);
                        foreach (PropertyInfo item in propertyArray)
                        {
                            item.SetValue(oObj, dr[item.Name]);
                        }
                        return (T)oObj;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return default(T);
        }
        public bool Insert<T>(T t) where T : BaseModel
        {
            bool flag = true;
            try
            {
                Type type = t.GetType();
                PropertyInfo[] propertyArray = type.GetProperties();
                string propertyStr = String.Join(",", propertyArray.Where(p => p.Name != "Id").Select(p => String.Format("[{0}]", p.Name)));
                string valueStr = String.Join(",", propertyArray.Where(p => p.Name != "Id").Select(p => String.Format("@{0}", p.Name)));

                string sqlStr = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", type.Name, propertyStr, valueStr);

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    SqlParameter[] sqlParameter = propertyArray
                        .Where(p => p.Name != "Id")
                        .Select(p => new SqlParameter(String.Format("@{0}", p.Name), p.GetValue(t) ?? DBNull.Value))
                        .ToArray();
                    comd.Parameters.AddRange(sqlParameter);
                    conn.Open();
                    int n = comd.ExecuteNonQuery();
                    conn.Close();
                    flag = n > 0;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
        public bool Update<T>(T t) where T : BaseModel
        {
            bool flag = true;
            try
            {
                Type type = t.GetType();
                PropertyInfo[] propertyArray = type.GetProperties();
                string propertyStr = String.Join(",", propertyArray.Where(p => p.Name != "Id").Select(p => String.Format("[{0}]=@{1}", p.Name, p.Name)));
                string sqlStr = String.Format("UPDATE [{0}] SET {1} WHERE ID={2}", type.Name, propertyStr, t.Id);

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    SqlParameter[] sqlParament = propertyArray
                        .Where(p => p.Name != "Id")
                        .Select(p => new SqlParameter(String.Format("@{0}", p.Name), p.GetValue(t)))
                        .ToArray();
                    comd.Parameters.AddRange(sqlParament);
                    conn.Open();
                    int n = comd.ExecuteNonQuery();
                    conn.Close();
                    flag = n > 0;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
        public bool Delete<T>(int id) where T : BaseModel
        {
            bool flag = true;
            try
            {
                Type type = typeof(T);
                string sqlStr = String.Format("DELETE FROM {0} WHERE ID={1}", "[" + type.Name + "]", id);

                using (SqlConnection conn = new SqlConnection(connectionStr))
                {
                    SqlCommand comd = new SqlCommand(sqlStr, conn);
                    conn.Open();
                    int n = comd.ExecuteNonQuery();
                    conn.Close();
                    flag = n > 0;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
    }
}
