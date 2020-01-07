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
        Dictionary<int, string> GetAwards();
        Dictionary<int, string> GetAwardsByUserId();
        bool AddNewAward(string awardName);
        bool RemoveAward(int awardId);
    }
}
