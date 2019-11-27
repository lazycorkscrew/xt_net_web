using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class Employee : User
    {

        public WorkStage Stage { get; }
        string CurrentPost { get; }

        public Employee(string fname, string lname, string patronymic, DateTime dateBirth,  WorkStage stage) 
        : base(fname, lname, patronymic, dateBirth)
        { 
            Stage = stage;

        }

        public void IncreaseTheStage( string sector,  string profession, int days)
        {
            Stage[sector][profession].IncreaseTheStage(days);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{Fname} {Lname} {Patronymic}, дата рождения: {DateBirth}, должность: ");
            
            foreach(WorkSector sector in Stage.Sectors)
            {
                builder.AppendLine($"{sector.SectorName}, стаж: {sector.GetGeneralExperience()}");

                foreach(WorkProfession prof in sector.Profession)
                {
                    builder.AppendLine($"\t{prof.ProfessionName}, стаж: {prof.Stage}");
                }
            }

            return builder.ToString();
        }
    }
}
