using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    //Общий стаж по всем сферам, в которых работал сотрудник
    public class WorkStage
    {
        public List<WorkSector> Sectors { get; }

        public WorkStage()
        {
            Sectors = new List<WorkSector>();
        }

        public WorkSector this[int index]
        {
            get
            {
                return Sectors[index];
                
            }
        }

        public WorkSector this[string sectorName]
        {
            get
            {
                int sectorCount = Sectors.Count;
                for (int i = 0; i < sectorCount; i++)
                {
                    if (Sectors[i].SectorName == sectorName)
                        return Sectors[i];
                }
                return null;
            }
        }

        public void AddSector(WorkSector newSector)
        {
            Sectors.Add(newSector);
        }

        //Возвращает строку со списком всех областей и опыта работы по каждой.
        public string GetSectors()
        {
            StringBuilder builder = new StringBuilder();
            foreach(WorkSector sector in Sectors)
            {
                builder.AppendLine($"{sector}, {sector.GetGeneralExperience()}");
            }

            return builder.ToString();
        }

        //Получить общий стаж по всем сферам
        public DateTime GetGeneralExperience()
        {
            DateTime generalDateTime = new DateTime();

            foreach (WorkSector sector in Sectors)
            {
                DateTime experience = sector.GetGeneralExperience();
                generalDateTime.AddYears(experience.Year);
                generalDateTime.AddMonths(experience.Month);
                generalDateTime.AddDays(experience.Day);
            }

            return generalDateTime;
        }


    }
}
