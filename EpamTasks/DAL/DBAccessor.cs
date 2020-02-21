using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTasks.IDAC;
using System.Data.SqlClient;
using System.Data;
using EpamTasks.Entities;
using System.IO;
using System.Data.Common;

namespace EpamTasks.DAL
{
    public class DBAccessor : IDBAccessorContracts
    {
        public static string connectionString = "Data Source=ХИМИК-ПК\\SQLEXPRESS; Initial Catalog=UsersAndRewards; Integrated Security=True";// False; User Id=; Password=" 


        public short CheckRightsVolume(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CheckRightsVolume", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                //return reader.Read() ? (short)reader["Power"] : -1;
                if (reader.Read())
                {
                    return (short)reader["Power"];
                }
                else return -1;
            }
        }

        public bool DeleteAward(int awardId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteAward", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", awardId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", id);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool DepriveUserOfAward(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DepriveUserOfAward", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@award_id", awardId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool GiveAwardToUser(int userId, int awardId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GiveAwardToUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@award_id", awardId);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool RegisterAward(string title)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegisterAward", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", title);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool RegisterUser(string name, string birthDate, string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegisterUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dateofbirth", birthDate);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public Award SelectAward(int awardId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectAward", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@award_id", awardId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Award award = new Award();
                if (reader.Read())
                {
                    award = new Award
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = reader.IsDBNull(2) ? null : (string)reader["Description"] 
                    };
                }

                return award;
            }
        }

        public byte[] SelectAwardImage(int awardId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageByAwardId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@award_id", awardId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    try
                    {
                        return (byte[])reader["Image"];
                    }
                    catch (InvalidCastException)
                    {
                        return null;
                    }
                }

                return null;
            }
        }

        public IEnumerable<Award> SelectAwards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectAwards", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Award> awards = new List<Award>();
                while (reader.Read())
                {
                    Award award = new Award();
                    award.Id = (int)reader["Id"];
                    award.Title = (string)reader["Title"];
                    award.Description = reader.IsDBNull(2)? null : (string)reader["Description"];
                    awards.Add(award);
                }

                return awards;
            }
        }

        public byte[] SelectDefaultImage()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectDefaultImage", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    try
                    {
                        return (byte[])reader["DefaultImage"];
                    }
                    catch (InvalidCastException)
                    {
                        return null;
                    }
                }

                return null;
            }
        }

        public User SelectFullUserInfo(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectFullUserInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Rank = (string)reader["Rank"]
                    };
                }

                return user;
            }
        }

        public User SelectShortUserInfo(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectFullUserInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    user = new User
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        DateOfBirth = DateTime.Parse((string)reader["DateOfBirth"]),
                        Rank = (string)reader["Rank"]
                    };
                }

                return user;
            }
        }

        public IEnumerable<User> SelectShortUsersInfo(int count, int offset)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectShortUsersInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@count", count);
                command.Parameters.AddWithValue("@offset", offset);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = (int)reader["Id"];
                    user.Name = (string)reader["Name"];
                    users.Add(user);

                    /*users.Add(new User { }
                    
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        DateOfBirth = DateTime.Parse((string)reader["DateOfBirth"]),
                        Rank = (string)reader["Rank"]})*/

                }

                return users;
            }
        }

        public IEnumerable<Award> SelectUserAwards(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectUserAwards", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Award> awards = new List<Award>();
                while (reader.Read())
                {
                    Award award = new Award();
                    award.Id = (int)reader["Id"];
                    award.Title = (string)reader["Title"];
                    awards.Add(award);
                }

                return awards;
            }
        }

        public byte[] SelectUserImage(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetImageByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    try
                    {
                        return (byte[])reader["Avatar"];
                    }
                    catch(InvalidCastException)
                    {
                        return null;
                    }
                }

                return null;
            }
        }

        public bool UpdateRights(int userId, int RightId)
        {
            throw new NotImplementedException();
        }

        public bool UploadImageToAward(int awardId, byte[] image)
        {
            throw new NotImplementedException();
        }

        public bool UploadImageToUser(int userId, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UploadImageToUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@image", image);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}
