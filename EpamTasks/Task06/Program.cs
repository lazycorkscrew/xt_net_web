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
            while(Menu())
            {
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static bool Menu()
        {
            Console.WriteLine("1 - Добавить пользователя {0}"+
                                "2 - Удалить пользователя{0}"+
                                "3 - Вывести список пользователей на экран{0}"+
                                "4 - Выход", Environment.NewLine);
            char key = Console.ReadKey(true).KeyChar;
            switch(key)
            {
                case '1': AddUser(); break;
                case '2': RemoveUser(); break;
                case '3': ShowAllUsers(); break;
                case '4': return false;
                default: break;
            }

            return true;
        }

        public static void AddUser()
        {
            Console.Clear();
            if(LogicProvider.UserLogic.AddUser(EnterTheNameForce(), EnterTheBirthDateTimeForce()))
            {
                Console.WriteLine("Пользователь добавлен.");
            }
            else
            {
                Console.WriteLine("Произошла ошибка добавления. Пожалуйста, свяжитесь с администратором.");
            }
        }

        public static void RemoveUser()
        {
            Console.Clear();
            Console.WriteLine("Введите ID удаляемого пользователя: ");
            if (LogicProvider.UserLogic.RemoveUserAt(EnterTheIdForce()))
            {
                Console.WriteLine("Пользователь удалён.");
            }
            else
            {
                Console.WriteLine("Пользователь не найден.");
            }

        }

        public static void ShowAllUsers()
        {
            Console.Clear();
            User[] users = LogicProvider.UserLogic.GetArray();
            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < users.Length; i++)
            {
                builder.AppendLine($"{users[i].Id} {users[i].Name}, дата рождения:  {users[i].DateOfBirth}, возраст: {users[i].Age}");
            }

            Console.WriteLine(builder.ToString());
        }

        public static string EnterTheNameForce()
        {
            Console.WriteLine("Введите имя пользователя.");
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

        public static int EnterTheIdForce()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");
            }

            return id;
        }
    }
}
