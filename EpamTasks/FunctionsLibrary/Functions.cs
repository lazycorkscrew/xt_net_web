using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsLibrary
{
    public static class Functions
    {
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

        public static string ArrayToString(int[] array)
        {
            string result = "{";
            foreach (int i in array)
            {
                result = $"{result}{i}, ";
            }

            return $"{result}}}";
        }

        public static int Max(int[] array)
        {
            if (array.Length <= 0)
            {
                return 0;
            }
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
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
