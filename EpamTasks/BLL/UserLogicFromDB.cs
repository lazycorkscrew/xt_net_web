using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTasks.Entities;
using EpamTasks.IBLC;
using System.Net.Mime;

namespace EpamTasks.BLL
{
    public class UserLogicFromDB : IUserLogicContracts
    {
        public bool AddNewAward(string awardName, byte[] image)
        {
            return DataAccessProvider.DBAccessor.RegisterAward(awardName, image);
        }

        public bool AddUser(string name, DateTime birthDay, string login, string password)
        {
            //throw new NotImplementedException();
            return DataAccessProvider.DBAccessor.RegisterUser(name, birthDay.Date.ToString("yyyy-MM-dd"), "qwerty", "qwerty");
        }

        public bool DepriveAward(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public DateTime EnterTheBirthDateTime(string dateTimeString)
        {
            throw new NotImplementedException();
        }

        public User[] GetArray()
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<int, Award> GetAwardById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwards()
        {
            return DataAccessProvider.DBAccessor.SelectAwards();
        }

        public IEnumerable<Award> GetAwardsByUserId(int id)
        {
            return DataAccessProvider.DBAccessor.SelectUserAwards(id);
        }

        public string GetImageLocationByAwardId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetImageLocationByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id, bool needShortInfo)
        {
            return needShortInfo ? DataAccessProvider.DBAccessor.SelectShortUserInfo(id)
                : DataAccessProvider.DBAccessor.SelectFullUserInfo(id);
        }

        public bool GiveAwardToUser(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public bool LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAward(int awardId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserAt(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveInFile()
        {
            throw new NotImplementedException();
        }

        public byte[] SelectAwardImage(int awardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectShortUsersInfo(int count, int offset)
        {
            return DataAccessProvider.DBAccessor.SelectShortUsersInfo(count, offset);
        }

        public byte[] SelectUserImage(int userId)
        {
            throw new NotImplementedException();
        }

        public void SetImageLocationByAwardId(int id, string imagePath)
        {
            throw new NotImplementedException();
        }

        public void SetImageLocationByUserId(int id, string imagePath)
        {
            throw new NotImplementedException();
        }

        public string ShowAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
