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
        public uint Stage { get; private set; }

        public WorkProfession(string profession, uint stage = 0)
        {
            ProfessionName = profession;
            Stage = stage;
        }

        public void IncreaseTheStage(uint days)
        {
            Stage += days;
        }
    }
}
