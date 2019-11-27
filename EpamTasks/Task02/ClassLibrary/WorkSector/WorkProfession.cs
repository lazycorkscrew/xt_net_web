using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    //Должность
    public class WorkProfession
    {
        public string ProfessionName { get; }
        public DateTime Stage { get; }

        public WorkProfession(string profession, DateTime stage = new DateTime())
        {
            ProfessionName = profession;
            Stage = stage;
        }

        public void IncreaseTheStage(int days)
        {
            Stage.AddDays(days);
        }
    }
}
