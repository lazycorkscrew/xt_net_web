using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Task05
{
    class Program
    {
        static string mainPath = Path.Combine(Environment.CurrentDirectory, "Target");
        static bool needChange = false;

        static Dictionary<string, HistoryFile> History = new Dictionary<string, HistoryFile>();

        static FileSystemWatcher watcher = new FileSystemWatcher(mainPath);

        static void Main(string[] args)
        {
            if (!Directory.Exists(mainPath))
            {
                Directory.CreateDirectory(mainPath);
            }

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            Scan();

            bool wannaExit = false;
            while (!wannaExit)
            {
                Console.WriteLine("1 - Режим наблюдения.{0}2 - Режим восстановления.{0}3 - Выход.", Environment.NewLine);
                bool entered = false;
                while (!entered)
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1': ListenMode(); Console.WriteLine("Включён режим наблюдения."); entered = true; break;
                        case '2': BackupMode(); Console.WriteLine("Включён режим восстановления."); entered = true; break;
                        case '3': entered = true; wannaExit = true; break;
                        default: Console.WriteLine("Неверное значение."); break;
                    }
                }
                Console.WriteLine("\nДля того, чтобы выйти, нажмите любую клавищу.");
                Console.ReadKey();
                watcher.EnableRaisingEvents = false;
                Console.Clear();
            }
        }
        
        static void ListenMode()
        {
            watcher.EnableRaisingEvents = true;
        }

        static void Scan()
        {
            if (!File.Exists("History.txt"))
            {
                File.Create("History.txt").Close();
            }
            
            string content = TryFileReadAllText("History.txt");

            History = JsonConvert.DeserializeObject<Dictionary<string, HistoryFile>>(content);

            if (History == null)
            {
                History = new Dictionary<string, HistoryFile>();
            }

            {
                DirectoryInfo info = new DirectoryInfo(mainPath);
                FileInfo[] files = info.GetFiles("*.txt", SearchOption.AllDirectories);

                foreach (FileInfo fileInfo in files)
                {
                    if (!History.ContainsKey(fileInfo.FullName))
                    {
                        History.Add(fileInfo.FullName, new HistoryFile(TryFileReadAllText(fileInfo.FullName)));
                    }
                }

                foreach (string key in History.Keys)
                {
                    if (!files.Any(a => a.FullName == key))
                    {
                        History[key].DeleteFile();
                    }
                }
            }

            File.WriteAllText("History.txt", JsonConvert.SerializeObject(History));
            
        }

        static void BackupMode()
        {
            DateTimeForm form = new DateTimeForm(History);

            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Backup(form.listHistories);
            }
        }

        static void Backup(Dictionary<string, FileHistoryPart> listHistories)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(mainPath);
            foreach (FileInfo file in dirInfo.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in dirInfo.GetDirectories("*", SearchOption.AllDirectories))
            {
                dir.Delete();
            }

            foreach (KeyValuePair<string, FileHistoryPart> backupFile in listHistories)
            {
                if (backupFile.Value != null && backupFile.Value.Type != FileChangeType.Delete)
                {
                    FileInfo file = new FileInfo(backupFile.Key);
                    if (!Directory.Exists(file.DirectoryName))
                    {
                        Directory.CreateDirectory(file.DirectoryName);
                    }
                    File.WriteAllText(backupFile.Key, backupFile.Value.Content, Encoding.UTF8);
                }
            }
        }

        static string TryFileReadAllText(string path)
        {
            bool isReadCompleted = false;
            string content = string.Empty;
            while(!isReadCompleted)
            {
                try
                {
                    content = File.ReadAllText(path, Encoding.UTF8);

                    isReadCompleted = true;
                }
                catch(Exception ex)
                {

                }
            }

            return content;
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            needChange = !needChange;
            if (needChange)
            { 

                Console.WriteLine($"{e.Name} - изменен\n");
                
                History[e.FullPath].WriteInHistory(TryFileReadAllText(e.FullPath));
                File.WriteAllText("History.txt", JsonConvert.SerializeObject(History));
            }
        }
        static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} - создан\n");

            if (!History.ContainsKey(e.FullPath))
            {
                
                History.Add(e.FullPath, new HistoryFile(TryFileReadAllText(e.FullPath)));
            }
            else
            {
                History[e.FullPath].WriteInHistory(TryFileReadAllText(e.FullPath));
            }

            File.WriteAllText("History.txt", JsonConvert.SerializeObject(History));
        }
        static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} - удален\n");
            History[e.FullPath].DeleteFile();
            File.WriteAllText("History.txt", JsonConvert.SerializeObject(History));
        }
        static void OnRenamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} - переименован\n");

            File.WriteAllText("History.txt", JsonConvert.SerializeObject(History));
        }
    }
}
