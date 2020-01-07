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

        public int Age
        {
            get
            {
                return DateTime.Now.AddYears(-DateOfBirth.Year).Year - 1;
            }
        }

        public UserInfo(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }
}
