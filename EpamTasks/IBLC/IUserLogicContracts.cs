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
        bool AddNewAward(string awardName);
        bool RemoveAward(int awardId);
        bool GiveAwardToUser(int userId, int awardId);
        DateTime EnterTheBirthDateTime(string dateTimeString);
        string ShowAllUsers();
        User GetUserById(int id, bool needShortInfo);
        Award GetAwardById(int id);
        bool DepriveAward(int userId, int awardId);
        string GetImageByUserId(int id);
        bool SetImageByUserId(int id, byte[] image);
        string GetImageByAwardId(int id);
        bool SetImageByAwardId(int id, string imagePath);
        IEnumerable<User> SelectShortUsersInfo(int count, int offset);
        byte[] SelectUserImage(int userId);
        byte[] SelectAwardImage(int awardId);

        byte[] SelectDefaultImage();
        short CheckRightsVolume(string login, string password);
    }
}
