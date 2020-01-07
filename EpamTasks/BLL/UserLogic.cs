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
    }
}
