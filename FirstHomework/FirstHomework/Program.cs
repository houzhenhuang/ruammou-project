using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstHomework.DB.Interface;
using FirstHomework.DB.SqlService;
using FirstHomework.Model;

namespace FirstHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBHelper dbHelper = simpleFacetory.CreateFacetory();
            //获取实体
            {
                //Console.WriteLine("=================GetModel=======================");
                //Company m_company = dbHelper.GetModel<Company>(1);
                //Console.WriteLine("Id={0},Name={1}", m_company.Id, m_company.Name);

                //User m_user = dbHelper.GetModel<User>(1);
                //Console.WriteLine("Id={0},Name={1}", m_user.Id, m_user.Name);

            }
            //查询所有
            {
                Console.WriteLine("=================QueryList=======================");

                //var list_company = dbHelper.QueryList<Company>();
                //var list = list_company.ExentLinqWhere(p => p.Id > 0).OrderBy(o => o.Id).Skip(1).Take(2).Select(s => new
                //{
                //    Id = s.Id,
                //    Name = s.Name,
                //    IdName = s.Id.ToString() + s.Name
                //});
                //foreach (var item in list)
                //{
                //    Console.WriteLine("Id={0},Name={1},IdName={2}", item.Id, item.Name, item.IdName);
                //}

                var list_company = dbHelper.QueryList<Company>(p => p.Id >= 2 && p.Id <= 9 && p.Name.Contains("东"));
                foreach (var item in list_company)
                {
                    Console.WriteLine("Id={0},Name={1}", item.Id, item.Name);
                }

            }
            //添加
            {
                //Console.WriteLine("=================Insert=======================");

                //Company entity = new Company() { Name = "华为", CreateTime = DateTime.Now, CreatorId = 1, LastModifierId = 1, LastModifyTime = DateTime.Now };
                //if (dbHelper.Insert<Company>(entity))
                //{
                //    Console.WriteLine("添加成功");
                //}
            }
            //修改
            {
                //Console.WriteLine("=================Update=======================");
                //Company entity = dbHelper.GetModel<Company>(10);
                //entity.CreatorId = 3;
                //if (dbHelper.Update<Company>(entity))
                //{
                //    Console.WriteLine("修改成功");
                //}
            }
            //删除
            {
                //if (dbHelper.Delete<Company>(7))
                //{
                //    Console.WriteLine("删除成功");
                //}
            }
            Console.Read();
        }
    }
}
