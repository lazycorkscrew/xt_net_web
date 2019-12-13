using System;
using System.Collections.Generic;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Task1();
            Task2();*/
            Task3();
        }

        static void Task1()
        {
            Console.WriteLine("Задание 1: Карусель, карусель - это радость для нас! Но не для всех. Каждого второго она сбрасывает.");
            bool switcher = false;
            Roundelay<string> roundelay = new Roundelay<string>();
            roundelay.Enqueue("Алёша");
            roundelay.Enqueue("Сирёжа");
            roundelay.Enqueue("Петенька");
            roundelay.Enqueue("Коленька");
            roundelay.Enqueue("Максимка");
            roundelay.Enqueue("Геннадий");
            roundelay.Enqueue("Элеонора Фёдоровна");
            roundelay.Enqueue("Дядя Петя");
            roundelay.Enqueue("Тётя Мотя");
            roundelay.Enqueue("Какой-то рандомный чел пришёл погреться");
            roundelay.Enqueue("Лейтенант Фёдоров. Ваши документы?");

            while (roundelay.Count > 1)
            {
                Console.WriteLine($"{(switcher ? roundelay.Dequeue() : roundelay.Next())}");
                switcher = !switcher;
            }
            Console.WriteLine($"Остался один человек: {roundelay.Peek()}");
            Console.ReadKey();
        }

        static void Task2()
        {
            Console.WriteLine("Задание 2: Введите какое-нибудь английское предложение, а я посчитаю в нём количество одинаковых слов.");
            EntitiesCounter<string> stringsCounter = new EntitiesCounter<string>();
            stringsCounter.AddRange(Console.ReadLine().Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(stringsCounter.ToString());
            Console.ReadKey();
        }

        static void Task3()
        {
            Console.WriteLine("Задание 3: свой динамический массив, и бесконечный динамический массив.");
            DynamicArray<string> array = new DynamicArray<string>();

            array.AddRange(new string[] { "12", "23", "34", "45", "56", "67", "78", "89", "90", "011", "012", "013", "014", "015", "016", "017", "018","019" });
            CycledDynamicArray<string> array2 = new CycledDynamicArray<string>(array);//(array.Clone() as CycledDynamicArray<string>);
            //array2.AddRange(new string[] { "12", "23", "34", "45", "56", "67", "78", "89", "90", "011", "012", "013", "014", "015", "016", "017", "018", "019" });

            array2.AddRange(array2);

            IEnumerable<string> ienumArray = array2;

            foreach(string item in ienumArray)
            {
                Console.WriteLine(item);
            }

            //array2.AddRange(array2);
            //array2.Remove("90");
            //array.Insert("90", 17);
            //Console.WriteLine($"{array.Capacity} {array.Length}");
            //Console.WriteLine($"{array2.Capacity} {array2.Length}");
            //Console.WriteLine(array[-20]);

            int limit = 100;
            int iteration = 1;
            /*foreach(string value in array)
            {
                Console.WriteLine(value);
                if(iteration++ >= limit)
                {
                    break;
                }
            }*/

            Console.ReadKey();
        }

    }
}
