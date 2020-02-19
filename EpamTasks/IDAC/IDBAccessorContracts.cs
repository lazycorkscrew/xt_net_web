using EpamTasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.IDAC
{
    public interface IDBAccessorContracts
    {
        bool RegisterUser(string name, string birthDate, string login, string password);
        bool DeleteUser(int id);
        bool GiveAwardToUser(int userId, int awardId);
        bool DepriveUserOfAward(int userId, int awardId);
        bool RegisterAward(string newAwardName, byte[] image);
        bool DeleteAward(int awardName);
        bool UpdateRights(int userId, int RightId);
        IEnumerable<Award> SelectUserAwards(int userId);
        IEnumerable<Award> SelectAwards();
        User SelectShortUserInfo(int userId);
        IEnumerable<User> SelectShortUsersInfo(int count, int offset);
        User SelectFullUserInfo(int userId);
        int CheckRightsVolume(int userId);

        byte[] SelectUserImage(int userId);
        byte[] SelectAwardImage(int awardId);
    }
}
