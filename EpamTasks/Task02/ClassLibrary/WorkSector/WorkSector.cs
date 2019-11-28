using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    //Сфера должностей
    public class WorkSector
    {
        public string SectorName { get; }
        public List<WorkProfession> Profession { get;}

        public WorkSector(string sectorName)
        {
            SectorName = sectorName;
            Profession = new List<WorkProfession>();
        }

        public WorkProfession this[int index]
        {
            get
            {
                return Profession[index];
            }
        }

        public WorkProfession this[string profName]
        {
            get
            {
                int postsCount = Profession.Count;
                for (int i = 0; i < postsCount; i++)
                {
                    if(Profession[i].ProfessionName == profName)
                        return Profession[i];
                }
                return null;
            }
        }

        //Добавить новую должность в данной сфере
        public void AddWorkProfession(WorkProfession profession)
        {
            Profession.Add(profession);
        }

        //Общий стаж работы по данной сфере
        public uint GetGeneralExperience()
        {
            uint generalStage = 0;

            foreach(WorkProfession post in Profession)
            {
                generalStage += post.Stage;
            }

            return generalStage;
        }

        //Получить список областей и стаж по каждой области
        public string GetAllPosts()
        {
            StringBuilder strings = new StringBuilder();

            foreach(WorkProfession post in Profession)
            {
                strings.AppendLine($"{post.ProfessionName}, {post.Stage}");
            }

            return strings.ToString();
        }
    }
}
