using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            Intro();
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();
            Task11();
            Task12();
            Bonus();
        }

        public static void Intro()
        {
            Console.WriteLine("Добрый день. Давайте приступим к заданиям.");
            Console.ReadKey();
            Console.WriteLine("Оу, чуть не забыл... сейчас, цвет текста поменяю. Пару секунд.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВот так-то лучше :) Итак, первое задание: вычислить площадь прямоугольника.");
        }

        public static void Task1()
        {
            //Задание 1
            Console.WriteLine("\nЗадание № 1 - Площадь прямоугольника.");
            Console.WriteLine("Введите сторону А: ");
            float a = TryReadLineFloat();
            Console.WriteLine("Введите сторону B: ");
            float b = TryReadLineFloat();
            Console.WriteLine($"Площадь прямоугольника со сторонами {a} и {b} равна {a * b}.");
            Console.ReadKey();
        }

        public static void Task2()
        {
            //Задание 2
            Console.WriteLine("\nЗадание № 2 - прямоугольный треугольник из звёздочек. Сколько строк вы хотите им занять?");
            Console.WriteLine(FunctionsLibrary.Triangle(TryReadLineInt()));
            Console.ReadKey();
        }

        public static void Task3()
        {
            //Задание 3
            Console.WriteLine("\nЗадание № 3 - Равнобедренный треугольник из звёздочек. Сколько строк вы хотите им занять?");
            Console.WriteLine(FunctionsLibrary.AnotherTriangle(TryReadLineInt()));
            Console.ReadKey();
        }

        public static void Task4()
        {
            //Задание 4
            Console.WriteLine("\nЗадание № 4 - Ёлочка из звёздочек. Сколько строк вы хотите ей занять?");
            Console.WriteLine(FunctionsLibrary.XmasTree(TryReadLineInt()));
            Console.ReadKey();
        }

        public static void Task5()
        {
            //Задание 5
            Console.WriteLine($"\nЗадание № 5 - Сумма всех чисел от 1 до 1000, кратных 3 и 5 равна : {FunctionsLibrary.SumOfNumbers()}");
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void Task6()
        {
            //Задание 6
            ConsoleKeyInfo consoleKey;
            FunctionsLibrary.TextStyle textStyles = FunctionsLibrary.TextStyle.Default;

            do
            {
                Console.WriteLine("\nЗадание № 6 - Стили текста.");
                Console.WriteLine("1 - добавить/убрать Bold\n2 - добавить/убрать Italic\n3 - добавить/убрать Underline\nEnter - следующее задание");
                consoleKey = Console.ReadKey();

                switch (consoleKey.Key)
                {
                    case ConsoleKey.D1: textStyles ^= FunctionsLibrary.TextStyle.Bold; break;
                    case ConsoleKey.D2: textStyles ^= FunctionsLibrary.TextStyle.Italic; break;
                    case ConsoleKey.D3: textStyles ^= FunctionsLibrary.TextStyle.Underline; break;
                    default: break;
                }

                Console.Clear();
                Console.SetCursorPosition(0, 7);
                Console.Write($"\rТеперь стиль текста будет {textStyles.ToString()}");
                Console.SetCursorPosition(0, 0);
            }
            while (consoleKey.Key != ConsoleKey.Enter);
            Console.Clear();
        }

        public static void Task7()
        {
            //Задание 7
            Console.WriteLine("\nЗадание № 7 - Случайный массив: мин, макс, сортировка, вывод на экран.");
            Console.WriteLine(FunctionsLibrary.ArrayProcessing());
            Console.ReadKey();
        }

        public static void Task8()
        {
            //Задание 8
            Console.WriteLine("\nЗадание 8");
            int[,,] array = new int[r.Next(1, 4), r.Next(1, 10), r.Next(1, 10)];

            int iLenght = array.GetLength(0);
            int jLenght = array.GetLength(1);
            int kLenght = array.GetLength(2);

            for (int i = 0; i < iLenght; i++)
            {
                for (int j = 0; j < jLenght; j++)
                {
                    for (int k = 0; k < kLenght; k++)
                    {
                        array[i, j, k] = r.Next(-100, 100);
                    }
                }
            }

            Console.WriteLine(FunctionsLibrary.XYZArrayToString(array));
            Console.WriteLine("Нажмите что-нибудь, чтобы удалить все положительные числа из массива.");
            Console.ReadKey();
            FunctionsLibrary.NoPositive(array);
            Console.WriteLine(FunctionsLibrary.XYZArrayToString(array));
            Console.WriteLine("Готово.");
            Console.ReadKey();
        }

        public static void Task9()
        {
            //Задание 9
            Console.WriteLine("\nЗадание 9 - сумма неотрицательных чисел в массиве.");
            int[] array = new int[r.Next(10, 20)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-100, 100);
            }
            Console.WriteLine(FunctionsLibrary.ArrayToString(array));
            Console.WriteLine($"Сумма неотрицательных чисел для данного массива: {FunctionsLibrary.NonNegativSum(array)}");
            Console.ReadKey();
        }

        public static void Task10()
        {
            //Задание 10
            Console.WriteLine("\nЗадание 10 - сумма всех элементов с чётной суммой индексов в двумерном массиве.");
            int[,] array = new int[r.Next(5, 10), r.Next(5, 10)];
            int iLength = array.GetLength(0);
            int jLength = array.GetLength(1);

            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < jLength; j++)
                {
                    array[i, j] = r.Next(1, 100);
                }
            }
            Console.WriteLine(FunctionsLibrary.XYArrayToString(array));
            Console.WriteLine($"Cумма всех элементов с чётной суммой индексов для данного массива: {FunctionsLibrary.XYArrayEvenIndexesSum(array)}");
            Console.ReadKey();
        }

        public static void Task11()
        {
            //Задание 11
            Console.WriteLine("\nЗадание 11 - Средняя длина слов в введённой текстовой строке.");
            Console.WriteLine("Введите строку, и я посчитаю среднюю длину всех её слов...");
            Console.WriteLine($"{FunctionsLibrary.AverageStringLength(Console.ReadLine())}");
            Console.ReadKey();
        }

        public static void Task12()
        {
            //Задание 12
            Console.WriteLine("\nЗадание 12 - Дублирование символов.");
            Console.WriteLine("Введите исходную строку...");
            string firstString = Console.ReadLine();
            Console.WriteLine("Введите строку символов для дублирования...");
            Console.WriteLine(FunctionsLibrary.DoubleCharsInString(firstString, Console.ReadLine()));
            Console.ReadKey();
        }

        public static void Bonus()
        {
                Console.WriteLine("\nНебольшой бонус: Нажимайте на клавиатуре любой символ, и я выведу о нём информацию...");
                ConsoleKeyInfo c;
                do
                {
                    c = Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(FunctionsLibrary.CheckChar(c.KeyChar));
                }
                while (c.Key != ConsoleKey.Enter);
                
            }

        //Функция безопасного ввода целых чисел
        static int TryReadLineInt()
        {
            Console.Write("> ");
            int n;
            while (!(int.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Неправильно введено значение.");
                Console.Write("> ");
            }
            return n;
        }

        //Функция безопасного ввода вещественных чисел
        static float TryReadLineFloat()
        {
            Console.Write("> ");
            float n;
            while (!(float.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Неправильно введено значение.");
                Console.Write("> ");
            }
            return n;
        }
    }
}
