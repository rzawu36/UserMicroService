using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDao


    {
        public static List<User> listOfUsers = new List<User>(); 

        public static User GetUserById(int id)
        {
            foreach (User user in listOfUsers)
            {
               if (user.UserId == id)
                {
                    return user;
                }
               
            }
            return null;
        }

        public static User getUserByName(String userName)
        {
            foreach (User user in listOfUsers)
            {
                if (user.name.Equals(userName))
                {
                    return user;
                }
            }
            return null;
        }

        public static List<User> GetUsers()
        {
            return listOfUsers;
        }

        public static User CreateNewUser(User user)
        {
            listOfUsers.Add(user);
            return GetUserById(user.UserId);
        }

        public static void UpdateUser(User updateUser)
        {
            foreach (User user in listOfUsers)
            {
                if (user.UserId == updateUser.UserId)
                {
                    user.name = updateUser.name;
                    user.address = updateUser.address;
                    user.active = updateUser.active;
                    user.phone = updateUser.phone;
                    user.email = updateUser.email;
                    user.cityName = updateUser.cityName;
                    user.countryName = updateUser.countryName;
                    user.zipCode = updateUser.zipCode;

                }
            }

        }

        public static void deleteUserById(int id)
        {
            foreach (User user in listOfUsers)
            {
                if (user.UserId == id)
                {
                    listOfUsers.Remove(user);
                    break;
                }
            }
        }

        public static void deleteUser(User u)
        {
            foreach (User user in listOfUsers)
            {
               if (user.UserId == u.UserId)
                {
                    listOfUsers.Remove(user);
                    break;
                } 
            }
        }


    }
}