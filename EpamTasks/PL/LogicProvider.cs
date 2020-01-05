using EpamTasks.BLL;
using EpamTasks.IBLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.PL
{
    public static class LogicProvider
    {
        public static IUserLogicContracts UserLogic { get; }

        static LogicProvider()
        {
            UserLogic = new UserLogic();
        }
    }
}
