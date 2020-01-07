using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.IDAC
{
    public interface IFileAccessorContracts
    {
        bool SaveSerializedObject(object target, string fileName);
        T loadSerializedObject<T>(string fileName);
    }
}
