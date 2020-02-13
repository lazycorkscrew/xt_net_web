using EpamTasks.Entities;
using EpamTasks.IBLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.BLL
{
    public class UserLogic :IUserLogicContracts
    {
        Users users = new Users();

        public bool AddUser(string name, DateTime birthDay)
        {
            try
            {
                users.Add(name, birthDay);
                return true;
            }
            catch(ArgumentException)
            {
                return false;
            }
        }

        public bool RemoveUserAt(int id)
        {
            try
            {
                return users.RemoveUserAt(id);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public User[] GetArray()
        {
            return users.ToArray();
        }

        public bool LoadFromFile()
        {
            try
            {
                users = DataAccessProvider.FileAccessor.loadSerializedObject<Users>("UsersInfo.txt");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool SaveInFile()
        {
            return DataAccessProvider.FileAccessor.SaveSerializedObject(users, "UsersInfo.txt");
        }

        public Dictionary<int, string> GetAwards()
        {
            return users.Awards;
        }

        public Dictionary<int, string> GetAwardsByUserId()
        {
            throw new NotImplementedException();
        }

        public bool AddNewAward(string awardName)
        {
            return users.AddNewAward(awardName);
        }

        public bool RemoveAward(int awardId)
        {
            return users.RemoveAward(awardId);
        }

        public bool GiveAwardToUser(int userId, int awardId)
        {
            return users.GiveAwardToUser(userId, awardId);
        }

        public DateTime EnterTheBirthDateTime(string dateTimeString)
        {
            DateTime dateTime;
            DateTime.TryParse(dateTimeString, out dateTime);
            return dateTime;
        }

        public string ShowAllUsers()
        {
            User[] users = GetArray();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<ul>");
            for (int i = 0; i < users.Length; i++)
            {
                builder.AppendLine($"<li>{users[i].Id} {users[i].Name}, дата рождения:  {users[i].DateOfBirth}, возраст: {users[i].Age}</li>");

                for (int j = 0; j < users[i].Awards.Length; j++)
                {
                    builder.AppendLine($"<li>\t{users[i].Awards[j].Key}, в кол-ве {users[i].Awards[j].Value} шт.</li>");
                }
            }
            builder.AppendLine("</ul>");
            return builder.ToString();
        }
    }
}
