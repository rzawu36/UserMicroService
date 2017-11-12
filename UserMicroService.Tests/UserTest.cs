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
            ClearUserList();
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
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "Pera",
                address = "Adresa",
                email = "pera@email.com"
            };

            User user2 = new User
            {
                UserId = 2,
                name = "Pera2",
                address = "Adresa2",
                email = "pera@email.com2"
            };





            UserDao.CreateNewUser(user);
           

            UserDao.deleteUser(user2);
            Assert.AreEqual(1, UserDao.listOfUsers.Count);


        }

        [Test]
        public void Update_User_Success()
        {
            ClearUserList();
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
            UserDao.UpdateUser(updateUser);

            Assert.AreEqual("Pera2", UserDao.GetUserById(1).name);
            Assert.AreEqual("Adresa2", UserDao.GetUserById(1).address);
            Assert.AreEqual("pera@email.com", UserDao.GetUserById(1).email);
            Assert.AreEqual("21000", UserDao.GetUserById(1).zipCode);
            Assert.AreEqual("Novi Sad", UserDao.GetUserById(1).cityName);
            Assert.AreEqual("Serbia", UserDao.GetUserById(1).countryName);
            Assert.AreEqual("123345123", UserDao.GetUserById(1).phone);
            Assert.AreEqual(true, UserDao.GetUserById(1).active);
            //Assert.AreSame(updateUser, UserDao.GetUserById(1)); ovo poredi memorijske lokacije?



        }

        [Test]
        public void Update_User_Failed ()
        {
            ClearUserList();
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
            UserDao.UpdateUser(updateUser);

            Assert.AreEqual(null, UserDao.getUserByName("Pera1"));
            



        }

        [Test]
        public void Create_New_User_Success()
        {
            ClearUserList();
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



      

        [Test]
        public void Get_User_By_Name_Success()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };

            UserDao.CreateNewUser(user);
            List<User> usersByName = new List<User>();
            usersByName.Add(UserDao.getUserByName("John"));

            Assert.AreEqual(1, usersByName.Count());
        }

        [Test]
        public void Get_User_By_Name_Failed()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };

            UserDao.CreateNewUser(user);
            
            

            Assert.AreEqual(null, UserDao.getUserByName("Mickey"));
        }

        [Test]
        public void Delete_User_By_Id_Success()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };

            UserDao.CreateNewUser(user);
            Assert.AreEqual(1, UserDao.listOfUsers.Count());
            UserDao.deleteUserById(1);
            Assert.AreEqual(0, UserDao.listOfUsers.Count());
        }

        [Test]
        public void Get_Users_By_Id_Success()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };

           


            UserDao.CreateNewUser(user);
           

            Assert.AreEqual(user, UserDao.GetUserById(1));
        }

        [Test]
        public void Get_Users_By_Id_Failed()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };

            


            UserDao.CreateNewUser(user);
            Assert.AreEqual(null, UserDao.GetUserById(3));
        }

        [Test]
        public void Delete_User_By_Id_Failed()
        {
            ClearUserList();
            User user = new User
            {
                UserId = 1,
                name = "John",
                address = "STarogradska",
                email = "email@email.com"
            };
            UserDao.CreateNewUser(user);
            Assert.AreEqual(1, UserDao.listOfUsers.Count());
            UserDao.deleteUserById(2);
            Assert.AreEqual(1, UserDao.listOfUsers.Count());
            //da li se ovo ovako radi?
        }


    }
}
