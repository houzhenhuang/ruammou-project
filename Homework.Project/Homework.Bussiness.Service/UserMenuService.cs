using Homework.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.EF.Model;
using System.Data.Entity;

namespace Homework.Bussiness.Service
{
    public class UserMenuService : BaseService, IUserMenuService
    {
        private DbSet<User> _UserDbSet = null;
        public UserMenuService(DbContext dbContext) :
            base(dbContext)
        {
            this._UserDbSet = dbContext.Set<User>();
        }
        public UserMenuService(DbContext dbContext, int id) :
            base(dbContext)
        {
            this._UserDbSet = dbContext.Set<User>();
        }
        public void UserLastLogin(User user)
        {
            Console.WriteLine("test");
        }

        public User UserLogin(string account)
        {
            return this._UserDbSet.FirstOrDefault(u => u.Account.Equals(account) || u.Mobile.Equals(account) || u.Email.Equals(account));
        }
    }
}
