using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07
{
    class Program
    {
        static string regex1 = @"([0-2][0-9]|3[0-1])[-\.](0[1-9]|1[0-2])[-\.](1[8-9]|20)\d\d";
        static string regex2 = @"(<[\/]?([A-z][ =]?[A-z""' =\.:]*[ \/]?)>)";
        static string regex3 = @"\b[a-z0-9][a-z0-9_\.-]*[a-z0-9]@([a-z0-9\.]*\.[a-z0-9]{2,6})\b";
        static string regex41 = @"^((-\d)|(\d))+$";
        static string regex42 = @"^((-\d(\.|,)\d+e(-\d|\d))|(\d(\.|,)\d+e(-\d|\d)))+$";
        static string regex5 = @"\b(([0-1]\d|\d)|(2[0-3])):([0-5]\d)";

        static void Main(string[] args)
        {
            Console.WriteLine("Внимание! Если вам лень вводить строки - оставьте их пустыми, и программа будет использовать значения по умолчанию.\n");
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Console.ReadKey();
        }

        public static void Task1()
        {
            Console.WriteLine("Введите текст, в котором мне нужно проверить, содержится ли нём дата в формате\n dd-mm-yyyy.");
            string text = Console.ReadLine();
            if (text == string.Empty)
            {
                text = "2016год наступит 01-01-2016";
            }

            Console.WriteLine((ContainsDate(text) ? "В тексте содержится дата." : "В тексте даты нет."));
        }

        public static void Task2()
        {
            Console.WriteLine("Введите текст, в котором мне нужно заменить все HTML теги на символ _");
            string text = Console.ReadLine();
            if (text == string.Empty)
            {
                text = @"<b>Это</b> текст <i>с</i> <fontcolor=""red"">HTML</font> кодами";
            }

            Console.WriteLine(ReplaceHtmlTags(text));
        }

        public static void Task3()
        {
            Console.WriteLine("Введите текст, в котором мне нужно найти все адреса электронной почты.");
            string text = Console.ReadLine();
            if (text == string.Empty)
            {
                text = @"Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            }

            string[] matches = MatchAllEmails(text);
            for (int i = 0; i < matches.Length; i++)
            {
                Console.WriteLine(matches[i]);
            }
        }

        public static void Task4()
        {
            Console.WriteLine("Введите число, а я попытаюсь узнать, обычная ли нотация у этого числа, или научная.. Ну и вообще, число ли.");
            string resultText = "Это не число";
            switch (NotationOfNumber(Console.ReadLine()))
            {
                case 0: resultText = "Это число в обычной нотации"; break;
                case 1: resultText = "Это число в научной нотации"; break;
                default: break;
            }

            Console.WriteLine(resultText);
        }

        public static void Task5()
        {
            Console.WriteLine("Введите текст, в котором мне нужно посчитать, сколько раз в нём встречается правильное время.");
            string text = Console.ReadLine();
            if (text == string.Empty)
            {
                text = "В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.";
            }

            Console.WriteLine($"Время в тексте встречается {CountOfTimes(text)} раз.");
        }

        public static string ReplaceHtmlTags(string str)
        {
            return new Regex(regex2).Replace(str, "_");
        }

        public static bool ContainsDate(string str)
        {
            return new Regex(regex1).IsMatch(str);
        }

        public static string[] MatchAllEmails(string str)
        {
            string[] emails;
            MatchCollection matches = new Regex(regex3).Matches(str);
            emails = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                emails[i++] = match.Value;
            }

            return emails;
        }

        public static int NotationOfNumber(string str)
        {

            if (new Regex(regex41).IsMatch(str))
            {
                return 0;
            }
            else if (new Regex(regex42).IsMatch(str))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public static int CountOfTimes(string str)
        {
            return new Regex(regex5).Matches(str).Count;
        }
    }
}
