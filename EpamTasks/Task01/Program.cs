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
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день. Давайте приступим к заданиям.");
            Console.ReadKey();
            Console.WriteLine("Оу, чуть не забыл... сейчас, цвет текста поменяю. Пару секунд.");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВот так-то лучше :) Итак, первое задание: вычислить площадь прямоугольника.");

            //Задание 1
            Console.WriteLine("Введите сторону А: ");
            decimal a = TryReadLineDecimal();
            Console.WriteLine("Введите сторону B: ");
            decimal b = TryReadLineDecimal();
            Console.WriteLine($"Площадь прямоугольника со сторонами {a} и {b} равна {a*b}.");
            Console.ReadKey();

            //Задание 2
            Console.WriteLine($"\nЗадание № 2 - прямоугольный треугольник из звёздочек. Сколько строк вы хотите им занять?");
            Console.WriteLine(FunctionsLibrary.Triangle(TryReadLineInt()));
            Console.ReadKey();

            //Задание 3
            Console.WriteLine($"\nЗадание № 3 - Равнобедренный треугольник из звёздочек. Сколько строк вы хотите им занять?");
            Console.WriteLine(FunctionsLibrary.AnotherTriangle(TryReadLineInt()));
            Console.ReadKey();

            //Задание 4
            Console.WriteLine($"\nЗадание № 4 - Ёлочка из звёздочек. Сколько строк вы хотите ей занять?");
            Console.WriteLine(FunctionsLibrary.XmasTree(TryReadLineInt()));
            Console.ReadKey();

            //Задание 5
            Console.WriteLine($"\nЗадание № 5 - Сумма всех чисел, кратных 3 и 5 равна : {FunctionsLibrary.SumOfNumbers()}");
            Console.WriteLine();
            Console.ReadKey();
            
            //Задание 6
            ConsoleKeyInfo consoleKey;
            FunctionsLibrary.TextStyle textStyles = FunctionsLibrary.TextStyle.Default;
            
            do
            {
                Console.WriteLine($"\nЗадание № 6 - Стили текста.");
                Console.WriteLine("1 - добавить/убрать Bold\n2 - добавить/убрать Italic\n3 - добавить/убрать Underline\nEnter - следующее задание");
                consoleKey = Console.ReadKey();

                switch(consoleKey.Key)
                {
                    case ConsoleKey.D1 : textStyles ^= FunctionsLibrary.TextStyle.Bold; break;
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

            //Задание 7
            Console.WriteLine($"\nЗадание № 7 - Случайный массив: мин, макс, сортировка, вывод на экран.");
            Console.WriteLine(FunctionsLibrary.ArrayProcessing());
            Console.ReadKey();



            
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
        static decimal TryReadLineDecimal()
        {
            Console.Write("> ");
            decimal n;
            while (!(decimal.TryParse(Console.ReadLine(), out n) && n > 0))
            {
                Console.WriteLine("Неправильно введено значение.");
                Console.Write("> ");
            }
            return n;
        }
    }
}
