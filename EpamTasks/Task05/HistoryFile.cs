using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Task05
{
    public class HistoryFile
    {
        public List<FileHistoryPart> contentHistory = new List<FileHistoryPart>();
        
        public HistoryFile(string content)
        {
            contentHistory.Add(new FileHistoryPart(FileChangeType.Create, content, DateTime.Now));
        }

        public void WriteInHistory(string newContent)
        {
            contentHistory.Add(new FileHistoryPart(FileChangeType.Update, newContent, DateTime.Now));
        }

        public void AppendHistory(FileHistoryPart newHistoryPart)
        {
            contentHistory.Add(newHistoryPart);
        }

        public void DeleteFile()
        {
            contentHistory.Add(new FileHistoryPart(FileChangeType.Delete, string.Empty, DateTime.Now));
        }

        public FileHistoryPart ExtractByDate(DateTime dateTime)
        {
            IEnumerable<FileHistoryPart> a = from b in contentHistory where b.DateOfChange < dateTime select b;
            return a.LastOrDefault();
        }
    }
}
