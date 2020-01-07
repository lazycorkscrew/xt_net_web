using EpamTasks.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTasks.Entities;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать на реализацию 6-го таска \"Users\"\n");
            LogicProvider.UserLogic.LoadFromFile();
            while(Menu())
            {
                Console.Clear();
            }
        }

        public static bool Menu()
        {
            Console.WriteLine("1 - Добавить пользователя{0}"+
                                "2 - Удалить пользователя{0}"+
                                "3 - Вывести список пользователей на экран{0}"+
                                "4 - Вручить награду{0}" +
                                "5 - Редактор наград{0}" +
                                "6 - Выход", Environment.NewLine);
            switch(Console.ReadKey(true).KeyChar)
            {
                case '1': AddUser(); break;
                case '2': RemoveUser(); break;
                case '3': ShowAllUsers(); break;
                case '4': GiveAward(); break;
                case '5': AwardsEditor(); break;
                case '6': return false;
                default: break;
            }

            return true;
        }

        public static void AddUser()
        {
            Console.Clear();
            if(LogicProvider.UserLogic.AddUser(EnterTheNameForce("Введите имя пользователя."), EnterTheBirthDateTimeForce()))
            {
                LogicProvider.UserLogic.SaveInFile();
                Console.WriteLine("Пользователь добавлен.");
            }
            else
            {
                Console.WriteLine("Произошла ошибка добавления. Пожалуйста, свяжитесь с администратором.");
            }

            Console.ReadKey();
        }

        public static void RemoveUser()
        {
            Console.Clear();
            Console.WriteLine("Введите ID удаляемого пользователя: ");
            if (LogicProvider.UserLogic.RemoveUserAt(EnterTheIdForce()))
            {
                LogicProvider.UserLogic.SaveInFile();
                Console.WriteLine("Пользователь удалён.");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }

            Console.ReadKey();
        }

        public static void ShowAllUsers()
        {
            Console.Clear();
            User[] users = LogicProvider.UserLogic.GetArray();
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < users.Length; i++)
            {
                builder.AppendLine($"{users[i].Id} {users[i].Name}, дата рождения:  {users[i].DateOfBirth}, возраст: {users[i].Age}");

                for(int j = 0; j < users[i].Awards.Length; j++)
                {
                    builder.AppendLine($"\t{users[i].Awards[j].Key}, в кол-ве {users[i].Awards[j].Value} шт.");
                }
            }

            Console.WriteLine(builder.ToString());
            Console.ReadKey();
        }

        public static void GiveAward()
        {

            if(LogicProvider.UserLogic.GiveAwardToUser(EnterTheIdForce("Введите ID пользователя."), EnterTheIdForce("Введите ID награды.")))
            {
                LogicProvider.UserLogic.SaveInFile();
                Console.WriteLine("Награда вручена.");
            }
            else
            {
                Console.WriteLine("Данная награда не может быть вручена.");
            }

            Console.ReadKey();
        }

        public static bool AwardsMenu()
        {
            Console.WriteLine("1 - Добавить награду{0}" +
                                "2 - Удалить награду{0}" +
                                "3 - Вывести список возможных наград на экран{0}" +
                                "4 - Назад{0}", Environment.NewLine);
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1': AddNewAward(); break;
                case '2': RemoveAward(); break;
                case '3': ShowAwards(); Console.ReadKey(); break;
                case '4': return false;
                default: break;
            }

            return true;
        }

        public static void AwardsEditor()
        {
            Console.Clear();
            while (AwardsMenu())
            {
                Console.Clear();
            }
        }

        public static void AddNewAward()
        {
            if(LogicProvider.UserLogic.AddNewAward(EnterTheNameForce("Введите название новой награды:")))
            {
                LogicProvider.UserLogic.SaveInFile();
                Console.WriteLine("Новая награда добавлена.");
            }
            else
            {
                Console.WriteLine("Такая награда уже существует.");
            }

            Console.ReadKey();
        }

        public static void RemoveAward()
        {
            ShowAwards();
            if (LogicProvider.UserLogic.RemoveAward(EnterTheIdForce("Введите ID удаляемой награды:")))
            {
                LogicProvider.UserLogic.SaveInFile();
                Console.WriteLine("Награда удалена.");
            }
            else
            {
                Console.WriteLine("Такая награда не существует.");
            }

            Console.ReadKey();
        }

        public static void ShowAwards()
        {
            //Console.Clear();
            Dictionary<int, string> awards = LogicProvider.UserLogic.GetAwards();
            foreach (KeyValuePair<int, string> award in awards)
            {
                Console.WriteLine($"{award.Key} {award.Value}");
            }
        }

        public static string EnterTheNameForce(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static DateTime EnterTheBirthDateTimeForce()
        {
            Console.WriteLine("Введите дату рождения: ");
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime) || dateTime > DateTime.Now)
            {
                Console.WriteLine("Введена некорректная дата. Попробуйте ещё раз.");
            }

            return dateTime;
        }

        public static int EnterTheIdForce(string message = "")
        {
            if(message != "")
            {
                Console.WriteLine(message);
            }

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");
            }

            return id;
        }
    }
}
