using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public static class FunctionsLibrary
    {
        public static void CustomSort<T>(T[] arrayToWork, Func<T, T, bool> Comparer)
        {
            T temp;
            for (int i = 1; i != arrayToWork.Length; i++)
            {
                for (int j = 0; j < arrayToWork.Length - i; j++)
                {
                    if (Comparer.Invoke(arrayToWork[j], arrayToWork[j+1]))
                    {
                        temp = arrayToWork[j+1];
                        arrayToWork[j+1] = arrayToWork[j];
                        arrayToWork[j] = temp;
                    }
                }
            }
        }
    }
}
