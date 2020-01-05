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
                return users.RemoveAt(id);
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
            return false;
        }

    }
}
