using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;

using WebApiDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApiDemo.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// User Data List
        /// </summary>
        private List<Users> _userList = new List<Users>
        {
            new Users {UserID = 1, UserName = "Superman", UserEmail = "Superman@cnblogs.com"},
            new Users {UserID = 2, UserName = "Spiderman", UserEmail = "Spiderman@cnblogs.com"},
            new Users {UserID = 3, UserName = "Batman", UserEmail = "Batman@cnblogs.com"}
        };

        #region HttpGet
        // GET api/users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _userList;
        }

        // GetUserById api/users/5
        [HttpGet]
        public Users GetUserById(int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];

            var user = _userList.SingleOrDefault(u => u.UserID == id);

            return user;
        }
        [HttpGet]
        public IEnumerable<Users> GetUserByNameId(string userName, int id)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];

            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }
        [HttpGet]
        public IEnumerable<Users> GetUserByModel(Users user)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];
            string emai = HttpContext.Current.Request.QueryString["email"];

            return _userList;
        }

        [HttpGet]
        public IEnumerable<Users> GetUserByModelUri([FromUri]Users user)
        {
            string idParam = HttpContext.Current.Request.QueryString["id"];
            string userNameParam = HttpContext.Current.Request.QueryString["userName"];
            string emai = HttpContext.Current.Request.QueryString["email"];

            return _userList;
        }

        [HttpGet]
        public IEnumerable<Users> GetUserByModelSerialize(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }

        //[HttpGet]
        public IEnumerable<Users> GetUserByModelSerializeWithoutGet(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }
        /// <summary>
        /// 方法名以Get开头，WebApi会自动默认这个请求就是get请求，而如果你以其他名称开头而又不标注方法的请求方式，那么这个时候服务器虽然找到了这个方法，但是由于请求方式不确定，所以直接返回给你405——方法不被允许的错误。
        /// 最后结论：所有的WebApi方法最好是加上请求的方式（[HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]），不要偷懒，这样既能防止类似的错误，也有利于方法的维护，别人一看就知道这个方法是什么请求。
        /// </summary>
        /// <param name="userString"></param>
        /// <returns></returns>
        public IEnumerable<Users> NoGetUserByModelSerializeWithoutGet(string userString)
        {
            Users user = JsonConvert.DeserializeObject<Users>(userString);
            return _userList;
        }
        
        #endregion

        #region HttpPost
        //POST api/Users/RegisterNone
        [HttpPost]
        public Users RegisterNone()
        {
            return _userList.FirstOrDefault();
        }

        [HttpPost]
        public Users RegisterNoKey([FromBody]int id)
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        //POST api/Users/register
        //只接受一个参数的需要不给key才能拿到
        [HttpPost]
        public Users Register([FromBody]int id)//可以来自FromBody   FromUri
        //public Users Register(int id)//可以来自url
        {
            string idParam = HttpContext.Current.Request.Form["id"];

            var user = _userList.FirstOrDefault(users => users.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        //POST api/Users/RegisterUser
        [HttpPost]
        public Users RegisterUser(Users user)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["UserID"];
            string nameParam = HttpContext.Current.Request.Form["UserName"];
            string emailParam = HttpContext.Current.Request.Form["UserEmail"];

            //var userContent = base.ControllerContext.Request.Content.ReadAsFormDataAsync().Result;
            var stringContent = base.ControllerContext.Request.Content.ReadAsStringAsync().Result;
            return user;
        }


        //POST api/Users/register
        [HttpPost]
        public string RegisterObject(JObject jData)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = jData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }

        [HttpPost]
        public string RegisterObjectDynamic(dynamic dynamicData)//可以来自FromBody   FromUri
        {
            string idParam = HttpContext.Current.Request.Form["User[UserID]"];
            string nameParam = HttpContext.Current.Request.Form["User[UserName]"];
            string emailParam = HttpContext.Current.Request.Form["User[UserEmail]"];
            string infoParam = HttpContext.Current.Request.Form["info"];
            dynamic json = dynamicData;
            JObject jUser = json.User;
            string info = json.Info;
            var user = jUser.ToObject<Users>();

            return string.Format("{0}_{1}_{2}_{3}", user.UserID, user.UserName, user.UserEmail, info);
        }
        #endregion HttpPost


        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
