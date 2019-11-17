using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число, и я напишу все числа от 1 до вашего: ");
            Console.WriteLine(FunctionsLibrary.Sequence(TryReadLineInt()));
            Console.ReadKey();

            Console.WriteLine("\n\nВведите целое число, и я вам скажу, является ли оно простым: ");
            Console.WriteLine(FunctionsLibrary.Prime(TryReadLineInt())? "Число простое." : "Число не простое." );
            Console.ReadKey();

            Console.WriteLine("\n\nВведите целое число, и я вам нарисую квадрат из звёздочек, а в середине пусто: ");
            Console.WriteLine(FunctionsLibrary.Square(TryReadLineInt()));
            Console.ReadKey();

            Console.WriteLine("\n\nВведите размерность ступенчатого массива: ");
            int[][] doubleArray = new int[TryReadLineInt()][];

            Random r = new Random();
            for(int i = 0; i < doubleArray.Length; i++)
            {
                Console.WriteLine( $"Введите размерность {i+1}-го вложенного массива из {doubleArray.Length}: ");
                doubleArray[i] = new int[TryReadLineInt()];

                for(int j = 0; j < doubleArray[i].Length; j++)
                {
                    doubleArray[i][j] = r.Next(1, 101);
                    Console.Write($"{doubleArray[i][j]}, ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine($"\n Ваш отсортированный двумерный массив: \n{FunctionsLibrary.ArrayToString(FunctionsLibrary.DoubleSort(doubleArray, true))}");
            Console.WriteLine($"\n Сортировка между массивов: \n{FunctionsLibrary.ArrayToString(FunctionsLibrary.DoubleSortBetweenArrays(doubleArray, true))}");
            Console.ReadKey();
        }

        //Функция безопасного ввода целых чисел
        static int TryReadLineInt()
        {
            Console.Write("> ");
            int n;
            while(!(int.TryParse(Console.ReadLine(), out n) && n>0))
            {
                Console.WriteLine("Неправильно введено значение.");
                Console.Write("> ");
            }
            return n;
        }
    }
}
