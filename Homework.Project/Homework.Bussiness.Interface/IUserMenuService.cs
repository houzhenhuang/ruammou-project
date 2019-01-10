using Homework.EF.Model;
using Homework.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Bussiness.Interface
{
    //[LoggerAttribute]
    public interface IUserMenuService : IBaseService
    {
        void UserLastLogin(User user);
        User UserLogin(string account);
    }
}
