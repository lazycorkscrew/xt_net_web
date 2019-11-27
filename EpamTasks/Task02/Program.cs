using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.ClassLibrary;

namespace Task02
{
    class Program
    {
        public delegate void YourCode();

        static void Main(string[] args)
        {
            /*//Task 2.1 Класс Round с координатами, радиусом и т.д.
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("Введите радиус окружности.");
                ClassLibrary.Round round;
                round = new ClassLibrary.Round(new Point(0, 0), TryReadLineDecimal());
                Console.WriteLine($"P = {round.P}, S = {round.S}");
                Console.ReadKey();
            });

            //Task 2.2 Класс Triangle (треугольник) с длинами.
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("Введите последовательно три стороны треугольника.");
                ClassLibrary.Triangle triangle = new ClassLibrary.Triangle(TryReadLineDecimal(), TryReadLineDecimal(), TryReadLineDecimal());
                Console.WriteLine($"P = {triangle.P}, S = {triangle.S}");
                Console.ReadKey();
            });

            //Task 2.3 Класс User (пользователь).
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("Введите имя");
                string fname = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                string lname = Console.ReadLine();
                Console.WriteLine("Введите отчество");
                string patronymic = Console.ReadLine();
                DateTime dateBirth = TryReadDateTime();
                User user = new User(fname, lname, patronymic, dateBirth);
                Console.WriteLine(user.ToString());
                Console.ReadKey();
            });

            MyString s = new MyString("строка");
            MyString concatedString = s + s;
            

            foreach(char c in concatedString)
            {
                Console.Write(c);
            }
            Console.ReadKey();*/

            Employee people = new Employee("Гришин", "Максим", "Юрьевич", DateTime.Parse("22.06.1995"), new WorkStage());

            people.Stage.AddSector(new WorkSector("IT"));
            people.Stage["IT"].AddWorkProfession(new WorkProfession(".NET Программист", new DateTime(1, 1, 1)) );
            Console.WriteLine(people.ToString());
            Console.ReadKey();
        }


        public static void TryCatchAndWriteExceptions(YourCode code)
        {
            while (true)
            {
                try
                {
                    code?.Invoke();
                break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static DateTime TryReadDateTime()
        {
            Console.Write("> ");
            DateTime date;
            while (!(DateTime.TryParse(Console.ReadLine(), out date)))
            {
                try
                {
                    Console.WriteLine("Некорректная дата.");
                    Console.Write("> ");
                }
                catch (ArgumentOutOfRangeException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
            return date;
        }

        public static double TryReadLineDecimal()
        {
            Console.Write("> ");
            double n;
            while (!(double.TryParse(Console.ReadLine(), out n)))
            {
                try
                {
                    Console.WriteLine("Неправильно введено значение.");
                    Console.Write("> ");
                }
                catch(ArgumentOutOfRangeException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
            return n;
        }

        
    }
}
