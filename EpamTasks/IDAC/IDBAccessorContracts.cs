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
        bool RegisterAward(string newAwardName);
        bool DeleteAward(int awardName);
        bool UpdateRights(int userId, int RightId);

        void SelectUserAwards(int userId);
        void SelectShortUserInfo(int userId);
        void SelectFullUserInfo(int userId);
        void CheckRightsVolume(int userId);
    }
}
