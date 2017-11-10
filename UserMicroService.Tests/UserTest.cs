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

        [Test]
        public void Delete_User_Success()
        {
            User user = new User
            {
                UserId = 1,
                name = "Pera",
                address = "Adresa",
                email = "pera@email.com",
                zipCode = "22000",
                cityName = "Nov Sad",
                countryName = "erbia",
                phone = "12334512",
                active = false
            };

            User user2 = new User
            {
                UserId = 2,
                name = "Pera2",
                address = "Adresa2",
                email = "pera@email.com2",
                zipCode = "21000",
                cityName = "Novi Sad",
                countryName = "Serbia",
                phone = "123345123",
                active = true
            };



            UserDao.CreateNewUser(user);
            UserDao.CreateNewUser(user2);

            UserDao.deleteUser(user);
            Assert.AreEqual(1, UserDao.listOfUsers.Count);

        }

        [Test]
        public void Update_User_Success()
        {
            User user = new User
            {
                UserId = 1,
                name = "Pera1",
                address = "Adresa1",
                email = "pera@emailcom2",
                zipCode = "22000",
                cityName = "N2vi Sad",
                countryName = "Srbia",
                phone = "12334523",
                active = false
            };

            User updateUser = new User
            {
                UserId = 1,
                name = "Pera2",
                address = "Adresa2",
                email = "pera@email.com",
                zipCode = "21000",
                cityName = "Novi Sad",
                countryName = "Serbia",
                phone = "123345123",
                active = true
            };

            UserDao.CreateNewUser(user);
            UserDao.updateUser(updateUser);

            Assert.AreEqual("Pera2", UserDao.GetUserById(1).name);
            Assert.AreEqual("Adresa2", UserDao.GetUserById(1).address);
            Assert.AreEqual("pera@email.com", UserDao.GetUserById(1).email);
            Assert.AreEqual("21000", UserDao.GetUserById(1).zipCode);
            Assert.AreEqual("Novi Sad", UserDao.GetUserById(1).cityName);
            Assert.AreEqual("Serbia", UserDao.GetUserById(1).countryName);
            Assert.AreEqual("123345123", UserDao.GetUserById(1).phone);
            Assert.AreEqual(true, UserDao.GetUserById(1).active);


        }

        [Test]
        public void Create_New_User_Success()
        {
            User user = new User
            {
                UserId = 1,
                name = "Pera",
                address = "Adresa",
                email = "email@email.com"
            };

            UserDao.CreateNewUser(user);

            Assert.AreEqual(1, UserDao.listOfUsers.Count);
        }
    }
}
