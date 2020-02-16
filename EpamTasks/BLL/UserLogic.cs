using EpamTasks.Entities;
using EpamTasks.IBLC;
using System;
using System.Collections.Generic;
using System.IO;
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
                users.Add(name, birthDay, false, string.Empty);
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

        public User GetUserById(int id)
        {
            return users[id];
        }

        public User[] GetArray()
        {
            return users?.ToArray()?? new User[0];
        }

        public bool LoadFromFile()
        {
            Users temp = null;
            try
            {
                temp = DataAccessProvider.FileAccessor.loadSerializedObject<Users>(Settings1.Default.DataPath);
            }
            catch(Exception ex)
            {
                
            }

            if (temp != null)
            {
                users = temp;
            }
            else
            {
                users = new Users();
                return false;
            }

            return true;
        }

        public bool SaveInFile()
        {
            return DataAccessProvider.FileAccessor.SaveSerializedObject(users, Settings1.Default.DataPath);
        }

        public Dictionary<int, Award> GetAwards()
        {
            return users.Awards;
        }

        public KeyValuePair<int, Award> GetAwardById(int id)
        {
            return new KeyValuePair<int, Award> (id,  users.Awards[id]);
        }

        public Dictionary<int, Award> GetAwardsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetImageLocationByUserId(int id)
        {
            return users[id].ProfileImagePath ?? string.Empty;
        }

        public void SetImageLocationByUserId(int id, string imageName)
        {
            users.SetImageName(id, imageName);
        }

        public string GetImageLocationByAwardId(int id)
        {
            return Path.Combine(Settings1.Default.AwardsImagesPath, GetAwards()[id].ImagePath);
        }

        public void SetImageLocationByAwardId(int id, string imagePath)
        {
            users.Awards[id].ImagePath = imagePath;
        }


        public bool AddNewAward(string awardName, string imagePath)
        {
            return users.AddNewAward(awardName, imagePath);
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
            for (int i = 0; i < users.Length; i++)
            {
                builder.AppendLine($"{users[i].Id} {users[i].Name}, дата рождения:  {users[i].DateOfBirth}, возраст: {users[i].Age}");

                for (int j = 0; j < users[i].Awards.Length; j++)
                {
                    builder.AppendLine($"\t{users[i].Awards[j].Key}, в кол-ве {users[i].Awards[j].Value} шт.");
                }
            }
            return builder.ToString();
        }

        public bool DepriveAward(int userId, int awardId)
        {
            return users.DepriveAwardFromUser(userId, awardId);
        }
    }
}
