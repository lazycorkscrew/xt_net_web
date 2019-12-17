using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class ChangedString
    {
        public int Index { get; }
        public string OldValue { get; }
        public string NewValue { get; }
        public DateTime DateTimeOfChange { get; }
        public StringChangeType Type;

        public ChangedString(int index, StringChangeType type, string newValue, DateTime dateTime)
        {
            Index = index;
            Type = type;
            NewValue = newValue;
            DateTimeOfChange = dateTime;
        }
        

        public static List<ChangedString> Differences(string oldContent, string newContent )
        {
            List<ChangedString> differences = new List<ChangedString>();
            string[] oldLines = oldContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] newLines = newContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            
            for(int i = 0; i < oldLines.Length; i++)
            {
                int offset = 0;
                bool isDeleted = true;
                for(int j = i; j < newLines.Length; j++)
                {
                    if(oldLines[i] == newLines[j])
                    {
                        isDeleted = false;
                        i++;
                    }
                }

                if(isDeleted)
                {
                    differences.Add(new ChangedString(i, StringChangeType.Delete, "", DateTime.Now));
                    offset++;
                }
            }

            /*offset = 0;
            for (int i = 0; i < newLines.Length; i++)
            {
                bool isInserted = true;
                for (int j = i; j < oldLines.Length; j++)
                {
                    if(oldLines[j] == newLines[i])
                    {
                        isInserted = false;
                        i++;
                    }
                    else
                    {
                        offset++;
                    }
                }

                if(isInserted)
                {
                    differences.Add(new ChangedString(i, StringChangeType.Insert, newLines[i], DateTime.Now));
                }
            }*/

            return differences;
        }
    }
}
