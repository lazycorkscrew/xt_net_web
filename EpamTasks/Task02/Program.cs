using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 2.1 Класс Round с координатами, радиусом и т.д.
            Console.WriteLine("Введите радиус окружности.");
            ClassLibrary.Round round = new ClassLibrary.Round(new Point(0,0), TryReadLineDecimal());
            Console.WriteLine($"P = {round.P}, S = {round.S}");
            Console.ReadKey();

            //Task 2.2 Класс Triangle (треугольник) с длинами.
            Console.WriteLine("Введите последовательно три стороны треугольника.");
            ClassLibrary.Triangle triangle = new ClassLibrary.Triangle(TryReadLineDecimal(), TryReadLineDecimal(), TryReadLineDecimal());
            Console.WriteLine($"P = {triangle.P}, S = {triangle.S}");
            Console.ReadKey();
        }

        public static float TryReadLineDecimal()
        {
            Console.Write("> ");
            float n;
            while (!(float.TryParse(Console.ReadLine(), out n)))
            {
                try
                {
                    Console.WriteLine("Неправильно введено значение.");
                    Console.Write("> ");
                }
                catch(Exception argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
            return n;
        }
    }
}
