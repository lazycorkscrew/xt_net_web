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

        public bool AddUser(string name, DateTime birthDay, string login, string password)
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

        public User GetUserById(int id, bool needShortInfo)
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

        public IEnumerable<Award> GetAwards()
        {
            throw new  NotImplementedException();
            //return users.Awards;
        }

        public Award GetAwardById(int id)
        {
            throw new NotImplementedException();
            //return new KeyValuePair<int, Award> (id,  users.Awards[id]);
        }

        public IEnumerable<Award> GetAwardsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetImageByUserId(int id)
        {
            throw new NotImplementedException();
            //return users[id].ProfileImage ?? string.Empty;
        }

        public bool SetImageByUserId(int id, byte[] image)
        {
            throw new NotImplementedException();
            //users.SetImageName(id, imageName);
            //return true;
        }

        public string GetImageByAwardId(int id)
        {
            throw new NotImplementedException();
            //return Path.Combine(Settings1.Default.AwardsImagesPath, GetAwards()[id].ImagePath);
        }

        public bool SetImageByAwardId(int id, string imagePath)
        {
            throw new NotImplementedException();
            //users.Awards[id].ImagePath = imagePath;
        }


        public bool AddNewAward(string awardName)
        {
            throw new NotImplementedException();
            //return users.AddNewAward(awardName);
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
            DateTime.TryParse(dateTimeString, out DateTime dateTime);
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

        public IEnumerable<User> SelectShortUsersInfo(int count, int offset)
        {
            throw new NotImplementedException();
        }

        public byte[] SelectUserImage(int userId)
        {
            throw new NotImplementedException();
        }

        public byte[] SelectAwardImage(int awardId)
        {
            throw new NotImplementedException();
        }

        public byte[] SelectDefaultImage()
        {
            throw new NotImplementedException();
        }

        public short CheckRightsVolume(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
