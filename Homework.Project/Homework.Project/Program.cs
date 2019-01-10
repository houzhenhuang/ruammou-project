using Homework.Bussiness.Interface;
using Homework.Bussiness.Service;
using Homework.EF.Model;
using Homework.Project.ContainerHelper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContainerCreate containerInstance = ContainerCreate.CreateInstance();
                IUnityContainer container = containerInstance.GetContainer();
                #region 增用户 (随机测试10个用户)
                Console.WriteLine("****************增用户 (随机测试10个用户)***************");
                {
                    //List<User> userList = new List<User>();
                    //using (IUserMenuService service = container.Resolve<IUserMenuService>())
                    //{
                    //    User user = service.QueryList<User>().OrderByDescending(p => p.Id).FirstOrDefault();
                    //    int index = user.Id + 1;
                    //    for (int i = index; i < index + 10; i++)
                    //    {
                    //        userList.Add(new User()
                    //        {
                    //            Name = "随机用户" + i,
                    //            Account = "suiji" + i,
                    //            Password = "123456",
                    //            Email = i + "@qq.com",
                    //            Mobile = "1365467894" + i,
                    //            State = 1,
                    //            UserType = 2,
                    //            CreateTime = DateTime.Now,
                    //            CreatorId = 1,
                    //            LastModifierId = 1
                    //        });
                    //    }
                    //    service.InsertList<User>(userList);
                    //}
                }
                #endregion
                #region 增菜单 (随机测试10个菜单，要求起码三层父子关系id/parentid，SourcePath=父SourcePath+/+GUID)
                {
                    //using (IUserMenuService service = container.Resolve<IUserMenuService>())
                    //{
                    //一级菜单 
                    //Menu menu = new Menu() { ParentId = 0, Name = "数据库管理", Description = "数据库管理",State=0, MenuLevel = 1, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1,SourcePath="root/12" };
                    //service.Insert<Menu>(menu);

                    //二级菜单 
                    //List<Menu> menuList = new List<Menu>() {
                    //    new Menu() { ParentId = 12, Name = "系统数据库", Description = "系统数据库", State = 0, MenuLevel = 2, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/1" },
                    //      new Menu() { ParentId = 12, Name = "数据库快照", Description = "数据库快照", State = 0, MenuLevel = 2, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/2" },
                    //        new Menu() { ParentId = 12, Name = "Homework", Description = "Homework", State = 0, MenuLevel = 2, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/3" }};
                    //service.InsertList<Menu>(menuList);

                    //三级菜单
                    //List<Menu> menuList = new List<Menu>() {
                    //    new Menu() { ParentId = 13, Name = "Master", Description = "Master", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/1/1" },
                    //       new Menu() { ParentId = 13, Name = "Model", Description = "Model", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/1/2" },
                    //      new Menu() { ParentId = 14, Name = "数据库快照子级1", Description = "数据库快照子级1", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/2/1" },
                    //       new Menu() { ParentId = 14, Name = "数据库快照子级2", Description = "数据库快照子级2", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/2/2" },
                    //      new Menu() { ParentId = 15, Name = "表", Description = "表", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/3/1" },
                    //        new Menu() { ParentId = 15, Name = "视图", Description = "视图", State = 0, MenuLevel = 3, Sort = 1, CreateTime = DateTime.Now, CreatorId = 1, SourcePath = "root/12/3/2" }};
                    //service.InsertList<Menu>(menuList);
                    //}
                }
                #endregion

                #region 增菜单 (随机测试10个菜单，要求起码三层父子关系id/parentid，SourcePath=父SourcePath+/+GUID)
                {
                    //using (IUserMenuService service = container.Resolve<IUserMenuService>())
                    //{
                    //    User user = service.GetData<User>(2);
                    //    var menuList = service.QueryList<Menu>(p=>p.SourcePath.Contains("root/12"));
                    //    List<UserMenuMapping> mapList = new List<UserMenuMapping>();
                    //    foreach (var item in menuList)
                    //    {
                    //        mapList.Add(new UserMenuMapping() { UserId=user.Id,MenuId=item.Id});
                    //    }
                    //    service.InsertList<UserMenuMapping>(mapList);
                    //}
                }
                #endregion

                {
                    //using ()
                    //{

                  
                    IUserMenuService service = (IUserMenuService)container.Resolve(typeof(UserMenuService));// container.Resolve<IUserMenuService>();
                    User user = service.GetData<User>(2);
                    //service.UserLastLogin(new User());
                    Console.WriteLine("userId={0},userName={1}", user.Id, user.Name);
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
