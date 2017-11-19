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

        [Route("api/DeleteUser/{id}"), HttpDelete]
        public void DeleteUserById(int id)
        {
            UserDao.deleteUserById(id);
        }

        [Route("api/CreateUser/"), HttpPost]
        public void CreateUser(User user)
        {
            UserDao.createUser(user);
        }

        [Route("api/UpdateUser/{id}"), HttpPut]
        public void UpdateUser(User user)
        {
            UserDao.updateUser(user);
        }

        [Route("api/User/"), HttpGet]
        public List<User> GetUsers()
        {
            return UserDao.getAllUsers();
        }




    }
}