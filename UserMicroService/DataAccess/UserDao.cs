using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDao


    {

        public static User ReadRowFromDB(SqlDataReader reader)
        {
            User userToReturn = new User();
            userToReturn.UserId = (int)reader["Id"];
            userToReturn.name = reader["Name"] as string;
            userToReturn.email = reader["Email"] as string;
            userToReturn.address = reader["Address"] as string;
            userToReturn.UserTypeId = (int)reader["UserTypeId"];
            return userToReturn;
        }

        public static List<User> ReadAllFromDB(SqlDataReader reader)
        {
            List<User> usersToReturn = new List<User>();
            
            return null;
        }
        
        public static User GetUserById(int id)
        {
            try
            {
                User user = new User();
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString)) 
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                            SELECT 
                            * 
                        FROM [user].[User] 
                        where 
                        [Id] = @Id
                        ");
                    command.Parameters.Add("@Id", SqlDbType.Int, id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = ReadRowFromDB(reader);
                        }
                        else
                        {
                            //obrada izuzetka
                        }
                        
                    }
                    
                    
                }
                return user;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static User createUser(User user)
        {
            return null;
        }

        public static List<User> getAllUsers()
        {
            try
            {
                List<User> listOfUsers = new List<User>();
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"SELECT * FROM [user].[User]");

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        if (reader.Read())
                        {
                            //listOfUsers = ReadAllFromDb(reader);
                        }

                    }
                }
                return listOfUsers;

                }
            catch (Exception e )
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}