using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;

namespace ExpressionDemo
{
    public class ExpressionTest
    {
        public static void Show()
        {
            #region MyRegion
            {
                Func<int, int, int> func = (m, n) => m * n + 2;
                func.Invoke(3, 4);
                //表达式目录树：语法树，一种数据结构
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
                int iResult = exp.Compile()(3, 4);
            }
            #endregion

            #region 拼装表达式目录树
            {//拼装表达式目录树
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");//参数m
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");//参数n
                BinaryExpression binaryExpression = Expression.Multiply(parameterExpression, parameterExpression2);//m*n
                ConstantExpression constantExpression = Expression.Constant(2, typeof(int));
                BinaryExpression addExpression = Expression.Add(binaryExpression, constantExpression);

                Expression<Func<int, int, int>> exp = Expression.Lambda<Func<int, int, int>>(addExpression, new ParameterExpression[]
			    {
			    	parameterExpression, 
			    	parameterExpression2
			    });
                int iResult = exp.Compile()(3, 4);
            }
            #endregion

            #region 拼装表达式目录树    Expression<Func<People, bool>> lambda = x => x.Age > 5;
            {
                //Expression<Func<People, bool>> lambda = x => x.Age > 5;

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");
                // MemberExpression memberExperssion= Expression.Property(parameterExpression, typeof(People).GetProperty("Age"));
                MemberExpression memberExperssion = Expression.Field(parameterExpression, typeof(People).GetField("Id"));
                ConstantExpression constantExpression = Expression.Constant(5, typeof(int));
                BinaryExpression binaryExpression = Expression.GreaterThan(memberExperssion, constantExpression);
                Expression<Func<People, bool>> lambda = Expression.Lambda<Func<People, bool>>(binaryExpression, new ParameterExpression[]
			    {
			    	parameterExpression
			    });

                bool bResult = lambda.Compile()(new People
                {
                    Id = 1,
                    Name = "tmo",
                    Age = 23
                });
            }
            #endregion

            #region 拼装表达式目录树    Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");
            {
                //Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "x");
                MemberExpression memberExpression = Expression.Field(parameterExpression, typeof(People).GetField("Id"));
                MethodCallExpression toStringExp = Expression.Call(memberExpression, typeof(People).GetMethod("ToString"), new Expression[0]);
                MethodCallExpression equalsExp = Expression.Call(toStringExp, typeof(People).GetMethod("Equals"), new Expression[]
			    {
			    	Expression.Constant("5", typeof(string))
			    });
                Expression<Func<People, bool>> lambda = Expression.Lambda<Func<People, bool>>(equalsExp, new ParameterExpression[]
			    {
			    	parameterExpression
			    });
                bool bResult = lambda.Compile()(new People
                {
                    Id = 1,
                    Name = "tmo",
                    Age = 23
                });
            }
            #endregion

            {
                People people = new People
                {
                    Id = 1,
                    Name = "tmo",
                    Age = 23
                };

               // PeopleCopy peopleCocy = Trans<People, PeopleCopy>(people);

                Expression<Func<People, PeopleCopy>> lambda = p => new PeopleCopy() { Id = p.Id, Name = p.Name, Age = p.Age };

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "p");
                NewExpression newExpression = Expression.New(typeof(PeopleCopy));
                List<MemberBinding> memberBindingList = new List<MemberBinding>();

                foreach (var item in typeof(PeopleCopy).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(People).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(PeopleCopy).GetFields())
                {
                    MemberExpression field = Expression.Field(parameterExpression, typeof(People).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, field);
                    memberBindingList.Add(memberBinding);
                }

                Expression<Func<People, PeopleCopy>> lambda2 = Expression.Lambda<Func<People, PeopleCopy>>(Expression.MemberInit(newExpression, memberBindingList.ToArray()), new ParameterExpression[]
                {
                    parameterExpression
                });

                PeopleCopy peopleCocy2 = lambda2.Compile()(people);


                //PeopleCopy peopleCocy3 = TransExp<People, PeopleCopy>(people);

                #region 比较反射实现和表达式树实现哪个性能更好

                //TaskFactory taskFactory = new TaskFactory();
                //for (int i = 0; i < 2; i++)
                //{
                //    taskFactory.StartNew(() =>
                //    {
                        
                //    });
                //}
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    Trans<People, PeopleCopy>(people);
                }
                sw.Stop();
                Console.WriteLine("Trans方法用时：{0}", sw.ElapsedMilliseconds);

                //sw.Start();
                //for (int i = 0; i < 10000000; i++)
                //{
                //    TransExp<People, PeopleCopy>(people);
                //}
                //sw.Stop();
                //Console.WriteLine("TransExp方法用时：{0}", sw.ElapsedMilliseconds);
                #endregion

            }

        }

        #region 利用反射实现类型转换
        /// <summary>
        /// 利用反射实现类型转换
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            TOut tOut = Activator.CreateInstance<TOut>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                PropertyInfo propertyInfo = typeof(TIn).GetProperties().FirstOrDefault(p => p.Name.Equals(item.Name));
                if (propertyInfo != null)
                {
                    item.SetValue(tOut, propertyInfo.GetValue(tIn));
                }
            }
            foreach (var item in typeof(TOut).GetFields())
            {
                FieldInfo fieldInfo = typeof(TIn).GetFields().FirstOrDefault(p => p.Name.Equals(item.Name));
                if (fieldInfo != null)
                {
                    item.SetValue(tOut, fieldInfo.GetValue(tIn));
                }
            }
            return tOut;
        }
        #endregion

        #region 利用表达式树实+缓存现类型转换
        public static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        public static TOut TransExp<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("Key_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                NewExpression newExpression = Expression.New(typeof(TOut));
                List<MemberBinding> memberBindingList = new List<MemberBinding>();

                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression field = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, field);
                    memberBindingList.Add(memberBinding);
                }

                Expression<Func<TIn, TOut>> lambda2 = Expression.Lambda<Func<TIn, TOut>>(Expression.MemberInit(newExpression, memberBindingList.ToArray()), new ParameterExpression[]
                {
                    parameterExpression
                });

                _Dic[key] = lambda2.Compile();
            }
            return ((Func<TIn, TOut>)_Dic[key]).Invoke(tIn);
        }
        #endregion

    }
}
