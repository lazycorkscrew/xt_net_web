using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTasks.IDAC;
using System.Data.SqlClient;
using System.Data;
using EpamTasks.Entities;

namespace EpamTasks.DAL
{
    public class DBAccessor : IDBAccessorContracts
    {
        public static string connectionString = "Data Source=ХИМИК-ПК\\SQLEXPRESS; Initial Catalog=UsersAndRewards; Integrated Security=True";// False; User Id=; Password=" 

        public int CheckRightsVolume(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CheckRightsVolume", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.Read() ? (int)reader["Power"] : -1;
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

        public bool RegisterAward(string title, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegisterAward", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@image", image);
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

        public byte[] SelectAwardImage(int awardId)
        {
            throw new NotImplementedException();
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
                    award.Description = reader.IsDBNull(2)? null : (string)reader["Description"] ;
                    awards.Add(award);
                }

                return awards;
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
            throw new NotImplementedException();
        }

        public bool UpdateRights(int userId, int RightId)
        {
            throw new NotImplementedException();
        }
    }
}
