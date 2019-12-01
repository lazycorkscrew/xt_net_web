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
            
            //Task 2.1 Класс Round с координатами, радиусом и т.д.
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("\nTask 2.1");
                Console.WriteLine("Введите радиус окружности.");
                ClassLibrary.Round round;
                round = new ClassLibrary.Round(new Point(0, 0), TryReadLineDecimal());
                Console.WriteLine($"P = {round.P}, S = {round.Area}");
                Console.ReadKey();
                Console.Clear();
            });

            //Task 2.2 Класс Triangle (треугольник) с длинами.
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("\nTask 2.2");
                Console.WriteLine("Введите последовательно три стороны треугольника.");
                ClassLibrary.Triangle triangle = new ClassLibrary.Triangle(TryReadLineDecimal(), TryReadLineDecimal(), TryReadLineDecimal());
                Console.WriteLine($"P = {triangle.P}, S = {triangle.S}");
                Console.ReadKey();
                Console.Clear();
            });

            //Task 2.3 Класс User (пользователь).
            TryCatchAndWriteExceptions(delegate
            {
                Console.WriteLine("\nTask 2.3");
                Console.WriteLine("Введите имя");
                string fname = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                string lname = Console.ReadLine();
                Console.WriteLine("Введите отчество");
                string patronymic = Console.ReadLine();
                Console.WriteLine("Введите дату рождения");
                DateTime dateBirth = TryReadDateTime();
                User user = new User(fname, lname, patronymic, dateBirth);
                Console.WriteLine(user.ToString());
                Console.ReadKey();
                Console.Clear();
            });

            //Task 2.4 Своя строка и операции с ней
            {
                Console.WriteLine("\nTask 2.4");
                Console.WriteLine("Введите первую строку..");
                MyString s1 = new MyString(Console.ReadLine());
                Console.WriteLine("Введите вторую строку..");
                MyString s2 = new MyString(Console.ReadLine());
                Console.WriteLine($"Результат конкатенации: {s1 + s2}");

                Console.ReadKey();
                Console.WriteLine("Введите строку, в которой будем искать..");
                MyString checkString = new MyString(Console.ReadLine());

                Console.WriteLine("Введите строку, которую ищем в предыдущей строке..");
                MyString stringForFind = new MyString(Console.ReadLine());
                int result = checkString.IndexOf(stringForFind.ToString());
                string answer = result >= 0 ? $"имеет индекс {result}" : "не найдена";
                Console.WriteLine($"Строка {answer}");
                Console.ReadKey();
                Console.Clear();
            }

            //Task 2.5 Сотрудник
            {
                Console.WriteLine("\nTask 2.5 Employee.");
                Employee people = new Employee("Гришин", "Максим", "Юрьевич", DateTime.Parse("22.06.1995"), new WorkStage());
                people.Stage.AddSector(new WorkSector("IT"));
                people.Stage["IT"].AddWorkProfession(new WorkProfession(".NET C# Программист", 319));

                people.Stage.AddSector(new WorkSector("Продажи"));
                people.Stage["Продажи"].AddWorkProfession(new WorkProfession("Продавец-консультант в магазине", 8));
                people.Stage["Продажи"].AddWorkProfession(new WorkProfession("Продавец-консультант в салоне связи", 94));

                Console.WriteLine(people.ToString());
                Console.ReadKey();
                Console.Clear();
            }

            //Task 2.6
            {
                Console.WriteLine("\nTask 2.6 Ring.");
                Ring ring = new Ring(new Round(new Point(0, 0), 4), new Round(new Point(0, 0), 10), new Point(0, 0), Color.Green);
                Console.WriteLine(ring.ToString());
                Console.ReadKey();
                Console.Clear();
            }

            //Task 2.7
            {
                Console.WriteLine("\nTask 2.7 VectorEditor.");
                WorkSpace space = new WorkSpace(800, 600);
                space.Figures.Add(new Line(new Point(57, 89), new Point(98, 72)));
                space.Figures.Add(new Round(new Point(100, 100), 80));
                space.Figures.Add(new Round(new Point(300, 100), 80, true));
                space.Figures.Add(new ClassLibrary.Rectangle(new Point(500, 100), 80, 40));
                space.Figures.Add(new Ring(new Round(new Point(400, 100), 80), -24, new Point(550, 100)));

                Console.WriteLine(space.ToString());

                Console.WriteLine("\nСейчас откроется окно с прорисовкой некоторымх элементов. Нажмите любую клавишу...");
                Console.ReadKey();
                BitmapShower shower = new BitmapShower(space.Render());
                shower.ShowDialog();
                Console.ReadKey();
                Console.Clear();
            }

            //Task 2.8
            {
                Console.WriteLine("\nTask 2.8. Сейчас я выведу на консоль информацию об игровом поле вместе с объектами на нём.");
                GameField gameField = new GameField(200, 200);
                Size size = new Size(40, 40);
                gameField.SetPlayer(new Player(3, new Point(100,61), size));
                gameField.AddGameObject(new Enemy(new Point(100, 100), size));
                gameField.AddGameObject(new Block(new Point(100, 150), size));
                gameField.AddGameObject(new Bonus(new Point(150, 60), size, BonusType.Life, 1));

                Console.WriteLine(gameField.GamePlayer.IsCollide(gameField.GameObjects[0])? "Игрок и первый объект сталкиваются.": "Игрок и первый объект не сталкиваются.");

                Console.WriteLine(gameField.ToString());
                Console.ReadKey();
            }
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
