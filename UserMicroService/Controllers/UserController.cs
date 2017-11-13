using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/User/{id}"), HttpGet]
        public User GetUserById(int id)
        {
            return UserDao.GetUserById(id);
        }


    }
}