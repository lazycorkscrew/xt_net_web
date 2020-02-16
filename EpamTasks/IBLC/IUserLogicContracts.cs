using EpamTasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.IBLC
{
    public interface IUserLogicContracts
    {
        bool AddUser(string name, DateTime birthDay);
        bool RemoveUserAt(int id);
        User[] GetArray();
        bool LoadFromFile();
        bool SaveInFile();
        Dictionary<int, Award> GetAwards();
        Dictionary<int, Award> GetAwardsByUserId(int id);
        bool AddNewAward(string awardName, string imagePath);
        bool RemoveAward(int awardId);
        bool GiveAwardToUser(int userId, int awardId);
        DateTime EnterTheBirthDateTime(string dateTimeString);
        string ShowAllUsers();
        User GetUserById(int id);
        KeyValuePair<int, Award> GetAwardById(int id);
        bool DepriveAward(int userId, int awardId);
        string GetImageLocationByUserId(int id);
        void SetImageLocationByUserId(int id, string imagePath);
        string GetImageLocationByAwardId(int id);
        void SetImageLocationByAwardId(int id, string imagePath);
    }
}
