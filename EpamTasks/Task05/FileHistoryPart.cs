using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class FileHistoryPart
    {

        public string Content { get; set; }
        public DateTime DateOfChange { get; set; }
        public FileChangeType Type;

        public FileHistoryPart()
        {

        }

        public FileHistoryPart(FileChangeType type, string content, DateTime dateTime)
        {
            Type = type;
            Content = content;
            DateOfChange = dateTime;
        }
    }
}
