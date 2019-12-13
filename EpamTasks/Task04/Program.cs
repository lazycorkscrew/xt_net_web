using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task03;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

        static void Task1()
        {
            Console.WriteLine("Задание 1: свой универсальный метод сортировки массива.");
            Console.WriteLine("Давайте попробуем отсортировать им массив целых чисел.");
            int[] array = new int[] { 3, 5, 9, 1, 6, 45, 7, 78, 90 };
            ConsoleWriteAll(array);
            FunctionsLibrary.CustomSort(array, (i, j) => i > j);
            ConsoleWriteAll(array);
            Console.WriteLine("Ух ты. Получилось! Если честно - сам не ожидал, что заработает.\n");
            Console.ReadKey();
        }

        static void Task2()
        {
            Console.WriteLine("Задание 2: Демонстрация своего метода сортировки с массивом строк.");
            Console.WriteLine("Теперь попробуем отсортировать им массив строк.");
            string[] array = { "ab", "gh", "nv", "gm","gtm", "rtu", "ljh","nvg", "vmn", "nv", "yj", "zz", "45" };
            ConsoleWriteAll(array);
            FunctionsLibrary.CustomSort(array, (s1, s2) => string.Compare(s1, s2) > 0);
            ConsoleWriteAll(array);
            Console.WriteLine();
            Console.ReadKey();
        }

        static void Task3()
        {
            Console.WriteLine("Задание 3: модуль сортировки в отдельном потоке с событием.");
            Console.WriteLine("Пожалуйста, наберись терпения. Сейчас будет создаваться очень большой массив...");
            int[] array = new int[64000];
            Random r = new Random();
            bool endOfGame = false;

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(0, 1000);
            }

            ThreadSorter<int> sorter = new ThreadSorter<int>(array, (a, b) => a > b);
            sorter.OnSortingCompleted += delegate
            {
                string resultMessage = endOfGame ? "\nМассив отсортирован." : "\nМассив отсортирован, но пароль всё ещё не введён. "
                + "(Скажу по секрету - \nпароль: \"qwerty012345\")";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(resultMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            };

            sorter.CustomSort(array, (a,b) => a>b);
            sorter.Start();
            Console.WriteLine($"\nСортировка запущена. А пока я сортирую {array.Length} элементов...");
            Console.Write($"Введите пароль:\n> ");

            while (!(Console.ReadLine() == "qwerty012345"))
            {
                Console.Write("Неверный пароль. ");
            }
            Console.WriteLine("Доступ разрешён.");
            endOfGame = true;
            Console.ReadLine();
        }

        static void Task4()
        {
            Console.WriteLine("Задание 4: Демонстрация расширения метода для массива целых чисел.");
            int[] array = new int[] {5,6,8,4,1,2,5,9,7,3 };
            Console.Write($"Массив ");
            ConsoleWriteAll(array);
            Console.WriteLine($"Сумма элементов массива: {array.Sum()}\n");
            Console.ReadKey();
        }

        static void Task5()
        {
            Console.WriteLine("Задание 5: Введите строку, а я проверю, является ли она положительным целым числом.");
            Console.WriteLine(Console.ReadLine().IsPositiveInt()? "Да, это положительное целое число.":
                "Нет, строка не является положительным целым числом.");
            Console.WriteLine();
            Console.ReadKey();
        }

        static void Task6()
        {
            Console.WriteLine("Задание 6: I SEEK YOU! Засекаем время работы разных сортов делегатов.");
            int[] array = new int[800000];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-1000, 1000);
            }
            
            long [] times = MeasureTheSpeed(array, 20);

            Console.WriteLine($"Непосредственный метод: {times[0]} мс");
            Console.WriteLine($"Ссылка на делегат: {times[1]} мс");
            Console.WriteLine($"Делегат в виде анонимного метода: {times[2]} мс");
            Console.WriteLine($"делегат в виде лямбда: {times[3]} мс");
            Console.WriteLine($"LINQ без методов: {times[4]} мс");
            Console.WriteLine($"LINQ с методами: {times[5]} мс");
            Console.ReadKey();
        }
        
        public static bool IsPositive(int value)
        {
            return value > 0;
        }

        static long [] MeasureTheSpeed(int[] array, int iterations)
        {
            int functionsCount = 6;
            long[][] averages = new long[functionsCount][];
            long[] result = new long[functionsCount];
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < averages.Length; i++)
            {
                averages[i] = new long[iterations];
            }

            Func<int, bool> delegated = IsPositive;

            for (int i = 0; i < iterations; i++)
            {
                //Непосредственно
                stopwatch.Start();
                FindPositive(array);
                stopwatch.Stop();
                averages[0][i] = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();

                //Ссылка на делегат
                stopwatch.Start();
                Find(array, delegated);
                stopwatch.Stop();
                averages[1][i] = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();

                //Делегат в виде анонимного метода
                stopwatch.Start();
                Find(array, delegate (int value) { return value > 0; });
                stopwatch.Stop();
                averages[2][i] = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();

                //делегат в виде лямбда
                stopwatch.Start();
                Find(array, (k) => k > 0);
                stopwatch.Stop();
                averages[3][i] = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();

                //LINQ1
                var selectedValues1 = from v in array where v > 0 select v;
                stopwatch.Start();
                selectedValues1.Count();
                stopwatch.Stop();
                averages[4][i] = stopwatch.ElapsedMilliseconds;

                //LINQ2
                var selectedValues2 = array.Where((v) => v > 0);
                stopwatch.Start();
                selectedValues2.Count();
                stopwatch.Stop();
                averages[5][i] = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = averages[i].Sum() / averages[i].Length;
            }

            return result;
        }
        
        static int[] FindPositive(int [] array)
        {
            List<int> found = new List<int>(300);
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                if (array[i] > 0)
                {
                    found.Add(array[i]);
                }
            }

            return found.ToArray();
        }

        static int[] Find(int [] array, Func <int, bool> Where)
        {
            List<int> found = new List<int>(300);
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                if (Where(array[i]))
                {
                    found.Add(array[i]);
                }
            }

            return found.ToArray();
        }
        
        static void ConsoleWriteAll<T>(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
    }
}
