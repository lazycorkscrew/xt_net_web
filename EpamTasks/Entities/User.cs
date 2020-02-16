using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public KeyValuePair<Award, int>[] Awards { get; set; }
        public string ProfileImagePath { get; set; }
        public string Pass { get; set; }
    }
}
