using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.Entities
{
    public class UserInfo
    {
        public string Name { get; }
        public DateTime DateOfBirth { get; }
        public Dictionary<int, int> Awards { get; } = new Dictionary<int, int>();
        public bool AdminRights = false;
        public string ProfileImagePath = string.Empty;

        public void GiveAward(int awardId)
        {
            if (Awards.ContainsKey(awardId))
            {
                Awards[awardId]++;
            }
            else
            {
                Awards.Add(awardId, 1);
            }
        }

        public bool DepriveAward(int awardId)
        {
            if (Awards.ContainsKey(awardId))
            {
                if(Awards[awardId]>1)
                {
                    Awards[awardId]--;
                    return true;
                }
                else
                {
                    return Awards.Remove(awardId);
                }
            }
            else
            {
                return false;
            }
        }

        public int Age
        {
            get
            {
                return DateTime.Now.AddYears(-DateOfBirth.Year).Year - 1;
            }
        }

        public UserInfo(string name, DateTime dateOfBirth, bool adminRights, string profileImagePath)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            AdminRights = adminRights;
            ProfileImagePath = profileImagePath;
        }
    }
}
