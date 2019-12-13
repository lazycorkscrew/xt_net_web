using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task04
{
    public class ThreadSorter<T>
    {
        public delegate void SortingProgressHandler();
        public event SortingProgressHandler OnSortingCompleted = delegate { };
        public Thread _thread;

        public T[] Items { get; }
        public Func<T, T, bool> Comparer;
        
        public ThreadSorter(T[] arrayToWork, Func<T, T, bool> comparer)
        {
            Items = arrayToWork;
            Comparer = comparer;
        }

        public void Start()
        {
            _thread = new Thread(BeginSort);
            _thread.Start();
        }

        void BeginSort()
        {
            CustomSort(Items, Comparer);
            OnSortingCompleted.Invoke();
        }

        public void CustomSort(T[] arrayToWork, Func<T, T, bool> Comparer)
        {
            T temp;
            for (int i = 1; i != arrayToWork.Length; i++)
            {
                for (int j = 0; j < arrayToWork.Length - i; j++)
                {
                    if (Comparer.Invoke(arrayToWork[j], arrayToWork[j + 1]))
                    {
                        temp = arrayToWork[j + 1];
                        arrayToWork[j + 1] = arrayToWork[j];
                        arrayToWork[j] = temp;
                    }
                }
            }
        }

        ~ThreadSorter()
        {
            _thread?.Abort();
        }

    }
}
