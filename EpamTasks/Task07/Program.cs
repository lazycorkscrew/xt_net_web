using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex1 = @"([0-2][0-9]|3[0-1])[-\.](0[1-9]|1[0-2])[-\.](1[8-9]|20)\d\d";
            string regex2 = @"(<[\/]?([A-z][ =]?[A-z""' =\.:]*[ \/]?)>)";
            string regex3 = @"\b[a-z0-9][a-z0-9_\.-]*[a-z0-9]@([a-z0-9\.]*\.[a-z0-9]{2,6})\b";
        }
    }
}
