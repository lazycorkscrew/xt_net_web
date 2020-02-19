using EpamTasks.DAL;
using EpamTasks.IDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.BLL
{
    internal static class DataAccessProvider
    {
        internal static IFileAccessorContracts FileAccessor { get; }
        internal static IDBAccessorContracts DBAccessor { get; }

        static DataAccessProvider ()
        {
            FileAccessor = new FileAccessor();
            DBAccessor = new DBAccessor();
        }
    }
}
