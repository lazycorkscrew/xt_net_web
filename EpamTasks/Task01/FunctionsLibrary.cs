using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    static class FunctionsLibrary
    {
        //Task 1.2
        public static string Triangle(int n)
        {
            string result = string.Empty;
            for(int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    result = $"{result}*";
                }
                result = $"{result}{Environment.NewLine}";
            }

            return result;
        }

        //Task 1.3
        public static string AnotherTriangle(int n, int offset = 0)
        {
            string result = string.Empty;

            //Количество звёздочек на текущей строке
            int stars = 1;

            //Количество пробелов на текущей строке
            int spaces = n-1;
            
            for (int i = 1; i <= n; i++)
            {
                for (int o = 0; o < offset; o++)
                {
                    result = $"{result} ";
                }

                for (int j = 0; j < spaces; j++)
                {
                    result = $"{result} ";
                }
                spaces--;

                for (int k = 0; k < stars; k++)
                {
                    result = $"{result}*";
                }
                stars = (i * 2)+1;
                result = $"{result}{Environment.NewLine}";
            }

            return result;
        }

        //Task 1.4
        public static string XmasTree(int n)
        {
            string result = string.Empty;
            for(int i = 1; i <= n; i++)
            {
                result = $"{result}{AnotherTriangle(i, n-i)}";
            }

            return result;
        }

        //Task 1.5
        public static int SumOfNumbers(int n = 1000)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        //Task 1.6
        
        public enum TextStyle
        {
            Default = 0,
            Bold = 1,
            Italic = 2,
            Bold_Italic = Bold | Italic,
            Underline = 4,
            Bold_Underline = Bold | Underline,
            Italic_Underline = Italic | Underline,
            Bold_Italic_Underline = Bold | Italic | Underline
        }

        //Task 1.7
        public static string ArrayProcessing()
        {
            Random r = new Random();
            int[] array = new int[r.Next(1, 21)];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(100);
            }

            return $"Сгенерированный массив: {ArrayToString(array)}{Environment.NewLine}" +
                $"Максимальное: {Max(array)}, Минимальное: {Min(array)}{Environment.NewLine}" +
                $"Отсортированный массив: {ArrayToString(Sort(array))}";
        }

        //Task 1.8
        public static void NoPositive(int [,,] array)
        {
            int iLenght = array.GetLength(0);
            int jLenght = array.GetLength(1);
            int kLenght = array.GetLength(2);

            for (int i = 0; i < iLenght; i++)
            {
                for (int j = 0; j < jLenght; j++)
                {
                    for (int k = 0; k < kLenght; k++)
                    {
                        if(array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        //Task 1.9
        public static int NonNegativSum(int[] array)
        {
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] > 0)
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        //Task 1.10
        public static int XYArrayEvenIndexesSum(int[,] array)
        {
            int iLength = array.GetLength(0);
            int jLength = array.GetLength(1);
            int sum = 0;

            for (int i = 0; i < iLength; i++)
            {
                for (int j = 0; j < jLength; j++)
                {
                    if( (i+j) %2 == 0 )
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        public static string XYArrayToString(int[,] array)
        {
            int iLenght = array.GetLength(0);
            int jLenght = array.GetLength(1);

            string result = string.Empty;

            for (int i = 0; i < iLenght; i++)
            {
                result = $"{result}{{";
                for (int j = 0; j < jLenght; j++)
                {
                    result = $"{result}{array[i, j]}, ";
                }
                result = $"{result}}}\n";
            }

            return result;
        }

        public static string XYZArrayToString(int[,,] array)
        {
            int iLenght = array.GetLength(0);
            int jLenght = array.GetLength(1);
            int kLenght = array.GetLength(2);

            string result = string.Empty;

            for (int i = 0; i < iLenght; i++)
            {
                result = $"{result}{{\n";
                for (int j = 0; j < jLenght; j++)
                {
                    result = $"{result}    {{ ";
                    for (int k = 0; k < kLenght; k++)
                    {
                        result = $"{result}{array[i, j, k]}, ";
                    }
                    result = $"{result}}}\n";
                }
                result = $"{result}}}\n";
            }

            return result;
        }

        public static string ArrayToString(int [] array)
        {
            string result = "{";
            foreach(int i in array)
            {
                result = $"{result}{i}, ";
            }

            return $"{result}}}";
        }

        public static int Max(int [] array)
        {
            if (array.Length <= 0)
            {
                return 0;
            }
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if(array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static int Min(int[] array)
        {
            if (array.Length <= 0)
            {
                return 0;
            }
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static int[] Sort(int[] arrayToSort, bool onlyShow = false)
        {
            int[] arrayToWork = (onlyShow ? (int[])arrayToSort.Clone() : arrayToSort);
            int temp;

            for (int i = 1; i != arrayToWork.Length; i++)
            {
                for (int j = 0; j < arrayToWork.Length - i; j++)
                {
                    if (arrayToWork[j] > arrayToWork[j + 1])
                    {
                        temp = arrayToWork[j + 1];
                        arrayToWork[j + 1] = arrayToWork[j];
                        arrayToWork[j] = temp;
                    }
                }
            }

            return arrayToWork;
        }
    }
}
