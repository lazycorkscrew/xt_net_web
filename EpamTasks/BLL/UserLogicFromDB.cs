﻿using System;
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
        public bool AddNewAward(string awardName)
        {
            return DataAccessProvider.DBAccessor.RegisterAward(awardName);
        }

        public bool AddUser(string name, DateTime birthDay, string login, string password)
        {
            //throw new NotImplementedException();
            return DataAccessProvider.DBAccessor.RegisterUser(name, birthDay.Date.ToString("yyyy-MM-dd"), "qwerty", "qwerty");
        }

        public bool DepriveAward(int userId, int awardId)
        {
            return DataAccessProvider.DBAccessor.DepriveUserOfAward(userId, awardId);
            //throw new NotImplementedException();
        }

        public DateTime EnterTheBirthDateTime(string dateTimeString)
        {
            throw new NotImplementedException();
        }

        public User[] GetArray()
        {
            throw new NotImplementedException();
        }

        public Award GetAwardById(int id)
        {
            return DataAccessProvider.DBAccessor.SelectAward(id);
        }

        public IEnumerable<Award> GetAwards()
        {
            return DataAccessProvider.DBAccessor.SelectAwards();
        }

        public IEnumerable<Award> GetAwardsByUserId(int id)
        {
            return DataAccessProvider.DBAccessor.SelectUserAwards(id);
        }

        public string GetImageByAwardId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetImageByUserId(int id)
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
            return DataAccessProvider.DBAccessor.GiveAwardToUser(userId, awardId);
        }

        public bool LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAward(int awardId)
        {
            return DataAccessProvider.DBAccessor.DeleteAward(awardId);
        }

        public bool RemoveUserAt(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveInFile()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectShortUsersInfo(int count, int offset)
        {
            return DataAccessProvider.DBAccessor.SelectShortUsersInfo(count, offset);
        }

        public byte[] SelectUserImage(int userId)
        {
            return DataAccessProvider.DBAccessor.SelectUserImage(userId);
        }

        public byte[] SelectAwardImage(int awardId)
        {
            return DataAccessProvider.DBAccessor.SelectAwardImage(awardId);
        }

        public bool SetImageByUserId(int id, byte[] image)
        {
            return DataAccessProvider.DBAccessor.UploadImageToUser(id, image);
        }

        public bool SetImageByAwardId(int id, string imagePath)
        {
            throw new NotImplementedException();
        }

        public string ShowAllUsers()
        {
            throw new NotImplementedException();
        }

        public byte[] SelectDefaultImage()
        {
            return DataAccessProvider.DBAccessor.SelectDefaultImage();
        }

        public short CheckRightsVolume(string login, string password)
        {
            return DataAccessProvider.DBAccessor.CheckRightsVolume(login, password);
        }
    }
}
