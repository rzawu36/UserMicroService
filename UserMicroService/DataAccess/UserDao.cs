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

        public static User ReadAllFromDB(SqlDataReader reader) //treba da vraca usera
        {
            User userToReturn = new User();
            userToReturn.UserId = (int)reader["Id"];
            userToReturn.name = reader["Name"] as string;
            userToReturn.email = reader["Email"] as string;
            userToReturn.address = reader["Address"] as string;
            userToReturn.UserTypeId = (int)reader["UserTypeId"];
            return userToReturn;
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

        public static void createUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"Insert into [user].[Users] ([name], [address], [phone]) values (@Name, @Address, @Phone);");
                    command.Parameters.Add("@Id", SqlDbType.Int, user.UserId);

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = user.name;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = user.address;

                    command.Parameters.Add("@Phone", SqlDbType.NVarChar);
                    command.Parameters["@Phone"].Value = user.phone;
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                Console.Write(e);

            }
            
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
                            while (reader.Read())
                            {
                                User user = ReadAllFromDB(reader);
                                listOfUsers.Add(user);
                            }
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

        public static void deleteUserById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"
                    DELETE
                    from
                    [user].[User]
                    where
                    [Id] = @Id
                        ");
                    command.Parameters.Add("@Id", SqlDbType.Int, id);
                    connection.Open();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }  
        
        public static void updateUser(User user)
        {
            int userId = user.UserId;
            string nameToUpdate = user.name;
            string emailToUpdate = user.email;
            string addressToUpdate = user.address;
            string zipCodeToUpdate = user.zipCode;
            string cityNameToUpdate = user.cityName;
            string countryNameToUpdate = user.countryName;
            string phoneToUpdate = user.phone;
            bool  activeToUpdate = user.active;
            int userTypeIdToUpdate = user.UserTypeId;

            try
            {
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = String.Format(@"UPDATE [user].[User] set
                    [name] = @Name,
                    [email] = @Email,
                    [address] = @Address,
                    [zipcode] = @ZipCode,
                    [cityname] = @CityName,
                    [countryname] = @CountryName,
                    [phone] = @Phone
                    where [Id] = @Id
                    ");
                    command.Parameters.Add("@Id", SqlDbType.Int, userId);

                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = nameToUpdate;

                    command.Parameters.Add("Email", SqlDbType.NVarChar);
                    command.Parameters["@Email"].Value = emailToUpdate;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = addressToUpdate;

                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                    command.Parameters["@ZipCode"].Value = zipCodeToUpdate;

                    command.Parameters.Add("@CityName", SqlDbType.NVarChar);
                    command.Parameters["@CityName"].Value = cityNameToUpdate;

                    command.Parameters.Add("@CountryName", SqlDbType.NVarChar);
                    command.Parameters["@CountryName"].Value = countryNameToUpdate;

                    command.Parameters.Add("@Phone", SqlDbType.NVarChar);
                    command.Parameters["@Phone"].Value = phoneToUpdate;

                    connection.Open();
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }
        
        //metoda za kreiranje korisnika
        //updatovanje korisnika

    }
}