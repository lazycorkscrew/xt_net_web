using System;

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
            DynamicArray<string> array = new DynamicArray<string>();

            /*for(int i = 0; i < 79; i++)
            {
                array.Add(i.ToString());
                Console.WriteLine($"{array.Capacity} {array.Length}");
            }*/


            array.AddRange(new string[] { "12", "23", "34", "45", "56", "67", "78", "89", "90", "011", "012", "013", "014", "015", "016", "017", "018","019" });

            array.Remove("90");
            array.Insert("90", 17);
            Console.WriteLine($"{array.Capacity} {array.Length}");
            Console.ReadKey();
        }

    }
}
