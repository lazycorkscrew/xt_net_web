using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTasks.IDAC;
using System.Data.SqlClient;
using System.Data;

namespace EpamTasks.DAL
{
    public class DBAccessor : IDBAccessorContracts
    {
        public static string connectionString = "Data Source=SQLEXPRESS; Initial Catalog=UsersAndRewards; Integrated Security=True";// False; User Id=; Password=" 

        public void CheckRightsVolume(int userId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAward(int awardName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool DepriveUserOfAward(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public bool GiveAwardToUser(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public bool RegisterAward(string newAwardName)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(string name, string birthDate, string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegisterUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                param.Value = name;
                command.Parameters.Add(param);

                param = new SqlParameter("@birthDate", SqlDbType.Date);
                param.Value = birthDate;
                command.Parameters.Add(param);

                param = new SqlParameter("@login", SqlDbType.NVarChar, 50);
                param.Value = login;
                command.Parameters.Add(param);

                param = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                param.Value = password;
                command.Parameters.Add(param);

                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public void SelectFullUserInfo(int userId)
        {
            throw new NotImplementedException();
        }

        public void SelectShortUserInfo(int userId)
        {
            throw new NotImplementedException();
        }

        public void SelectUserAwards(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRights(int userId, int RightId)
        {
            throw new NotImplementedException();
        }
    }
}
