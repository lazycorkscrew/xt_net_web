using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.Entities
{
    class AwardsContainer
    {
        public Dictionary<int, int> Awards { get; set; }

        public void ToAward(int awardId)
        {
            if(Awards.ContainsKey(awardId))
            {
                Awards[awardId]++;
            }
            else
            {
                Awards.Add(awardId, 1);
            }
        }
    }
}
