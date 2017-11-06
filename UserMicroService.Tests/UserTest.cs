using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Tests
{
    public class UserTest
    {
        public void ClearUserList()
        {
            UserDao.listOfUsers.Clear();
        }

        [Test]
        public void Get_All_Users_Success()
        {
            User user = new User
            {
                UserId = 1,
                name = "Pera",
                address = "Adresa",
                email = "pera@email.com"
            };

            UserDao.CreateNewUser(user);

            Assert.AreEqual(1, UserDao.GetUsers().Count);
        }
    }
}
