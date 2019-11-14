namespace EpamTasks
{
    static class FunctionsLibrary
    {
        //Task 0.1
        public static string Sequence(int n)
        {
            if(n<=0)
            {
                return "0";
            }

            string result = $"1";

            for(int i = 2; i <= n; i++)
            {
                result = $"{result}, {i}";
            }

            return result;
        }

        //Task 0.2
        public static bool Prime(int n)
        {
            if ((n != 2) && (n % 2 == 0))
            {
                return false;
            }

            for (int i = 3; i < n; i+=2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Task 0.3 (Можно указывать как чётное, так и нечётное)
        public static string Square(int n)
        {
            string s = "";
            int halfN = n / 2;
            int halfNminus = halfN - 1;
            bool even = n % 2 == 0;

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (even)
                    {
                        s = ((y == halfN && x == halfN) ||
                            (y == halfN && x == halfNminus) ||
                            (y == halfNminus && x == halfN) ||
                            (y == halfNminus && x == halfNminus)) ? $"{s} " : $"{s}*";
                    }
                    else
                    {
                        s = (y == halfN && x == halfN) ? $"{s} " : $"{s}*";
                    }
                }
                if(y<(n-1))
                s = $"{s}\n";
            }
            return s;
        }

        //Task 0.4
        public static string ArrayToString(int [][] doubleArray)
        {
            string output = "{";

            for (int j = 0; j < doubleArray.Length; j++)
            {
                output = $"{output}{{";
                for (int k = 0; k < doubleArray[j].Length; k++)
                {
                    output = $"{output}{doubleArray[j][k]},";
                }
                output = $"{output}}} ";
            }

            return $"{output}}}";
        }
        
        /// <summary>
        /// Метод сортировки двойного массива. Сортирует сначала каждый вложенный массив, а затем массив массивов по первому элементу.
        /// </summary>
        /// <param name="arrayToSort">Двумерный массив, который необходимо отсортировать.</param>
        /// <param name="onlyCopy"> Если True - то работаем с копией массива.</param>
        /// <returns></returns>
        public static int[][] DoubleSort(int[][] arrayToSort, bool onlyCopy = false)
        {
            int[][] arrayToWork = (onlyCopy ? (int[][])arrayToSort.Clone() : arrayToSort);
            int[] temp;

            for(int i = 0; i < arrayToWork.Length; i++)
            {
                Sort(arrayToWork[i]);
            }

            for (int i = 1; i != arrayToWork.Length; i++)
            {
                for (int j = 0; j < arrayToWork.Length - i; j++)
                {
                    if (arrayToWork[j][0] > arrayToWork[j + 1][0])
                    {
                        temp = arrayToWork[j + 1];
                        arrayToWork[j + 1] = arrayToWork[j];
                        arrayToWork[j] = temp;
                    }
                }
            }
            return arrayToWork;
        }

        //Метод сортировки
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
