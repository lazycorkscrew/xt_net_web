using EpamTasks.IDAC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks.DAL
{
    public class FileAccessor : IFileAccessorContracts
    {
        public bool SaveSerializedObject(object target, string fileName)
        {
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(target));
                return true;
            }
            catch(Exception serEx)
            {
                return false;
            }
        }

        public T loadSerializedObject<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }

        
    }
}
