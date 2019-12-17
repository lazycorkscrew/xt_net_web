using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Task05
{
    class Program
    {
        static string mainPath = Path.Combine(Environment.CurrentDirectory, "Target");

        static void Main(string[] args)
        {
            if (!Directory.Exists(mainPath))
            {
                Directory.CreateDirectory(mainPath);
            }

            ListenMode();
            Console.ReadKey();

        }

        static void ListenMode()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(mainPath);
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;




            var z =ChangedString.Differences(File.OpenText(Path.Combine(mainPath,"old.txt")).ReadToEnd(), File.OpenText(Path.Combine(mainPath, "new.txt")).ReadToEnd());
            Thread.Sleep(1);
        }

        static void BackupMode()
        {

        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine($"{fileInfo.Name} - изменен\n");
            string s = sender.ToString();
        }
        static void OnCreated(object sender, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine($"{fileInfo.Name} - создан\n");
        }
        static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine($"{fileInfo.Name} - удален\n");
        }
        static void OnRenamed(object sender, FileSystemEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine($"{fileInfo.Name} - переименован\n");
        }
    }
}
