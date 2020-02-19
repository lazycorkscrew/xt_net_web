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
        bool AddUser(string name, DateTime birthDay, string login, string password);
        bool RemoveUserAt(int id);
        User[] GetArray();
        bool LoadFromFile();
        bool SaveInFile();
        IEnumerable<Award> GetAwards();
        IEnumerable<Award> GetAwardsByUserId(int id);
        bool AddNewAward(string awardName, byte[] image);
        bool RemoveAward(int awardId);
        bool GiveAwardToUser(int userId, int awardId);
        DateTime EnterTheBirthDateTime(string dateTimeString);
        string ShowAllUsers();
        User GetUserById(int id, bool needShortInfo);
        KeyValuePair<int, Award> GetAwardById(int id);
        bool DepriveAward(int userId, int awardId);
        string GetImageLocationByUserId(int id);
        void SetImageLocationByUserId(int id, string imagePath);
        string GetImageLocationByAwardId(int id);
        void SetImageLocationByAwardId(int id, string imagePath);
        IEnumerable<User> SelectShortUsersInfo(int count, int offset);
        byte[] SelectUserImage(int userId);
        byte[] SelectAwardImage(int awardId);
    }
}
