using Homework.Bussiness.Interface;
using Homework.Framework.Extension;
using Homework.Web.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Homework.EF.Model;
using Homework.Framework.Encrypt;
using Homework.Web.Core.Models;

namespace Homework.Mvc5.Utility
{
    /// <summary>
    /// 用户登录/退出
    /// </summary>
    public static class UserManage
    {
        public static LoginResult UserLogin(this HttpContextBase context, string name = "", string pwd = "", string verify = "")
        {
            if (string.IsNullOrEmpty(verify) || context.Session["VerfyCode"] == null || !context.Session["VerfyCode"].ToString().Equals(verify, StringComparison.OrdinalIgnoreCase))
            {
                return LoginResult.WrongVerify;
            }

            IUserMenuService service = DIFactory.GetContainer().Resolve<IUserMenuService>();
            User user = service.UserLogin(name);
            if (user == null)
            {
                return LoginResult.NoUser;
            }
            else if (!user.Password.Equals(MD5Encrypt.Encrypt(pwd)))
            {
                return LoginResult.WrongPwd;
            }
            else if (user.State == (int)UserState.Frozen)
            {
                return LoginResult.Frozen;
            }
            else
            {
                CurrentUser currentUser = new CurrentUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    Account = user.Account,
                    Email = user.Email,
                    Password = user.Password,
                    LoginTime = DateTime.Now
                };
                #region cookie
                HttpCookie userCookie = new HttpCookie("CurrentUser");
                userCookie.Value = JsonHelper.ObjectToString<CurrentUser>(currentUser);
                userCookie.Expires = DateTime.Now.AddMinutes(5);
                context.Response.Cookies.Add(userCookie);
                #endregion
                #region session
                context.Session["CurrentUser"] = currentUser;
                context.Session.Timeout = 3;//minute  session过期等于Abandon
                #endregion
                service.UserLastLogin(user);
                return LoginResult.Success;
            }
        }

        public static void UserLogout(this HttpContextBase context)
        {
            #region Cookie
            HttpCookie userCookie = context.Request.Cookies["CurrentUser"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddMinutes(-1);//设置过过期
                context.Response.Cookies.Add(userCookie);
            }

            #endregion Cookie

            #region Session
            var sessionUser = context.Session["CurrentUser"];
            if (sessionUser != null && sessionUser is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
                // logger.Debug(string.Format("用户id={0} Name={1}退出系统", currentUser.Id, currentUser.Name));
            }
            context.Session["CurrentUser"] = null;//表示将制定的键的值清空，并释放掉，
            context.Session.Remove("CurrentUser");
            context.Session.Clear();//表示将会话中所有的session的键值都清空，但是session还是依然存在，
            context.Session.RemoveAll();//
            context.Session.Abandon();//就是把当前Session对象删除了，下一次就是新的Session了   
            #endregion Session

        }

        public enum LoginResult
        {
            /// <summary>
            /// 登录成功
            /// </summary>
            [RemarkAttribute("登录成功")]
            Success = 0,
            /// <summary>
            /// 用户不存在
            /// </summary>
            [RemarkAttribute("用户不存在")]
            NoUser = 1,
            /// <summary>
            /// 密码错误
            /// </summary>
            [RemarkAttribute("密码错误")]
            WrongPwd = 2,
            /// <summary>
            /// 验证码错误
            /// </summary>
            [RemarkAttribute("验证码错误")]
            WrongVerify = 3,
            /// <summary>
            /// 账号被冻结
            /// </summary>
            [RemarkAttribute("账号被冻结")]
            Frozen = 4
        }
    }   
}