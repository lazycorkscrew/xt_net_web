using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03
{
    class Roundelay<T> : IEnumerable<T>
    {
        Queue<T> queue = new Queue<T>();

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        public void Clear()
        {
            queue.Clear();
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        public T Next()
        {
            T item = queue.Dequeue();
            queue.Enqueue(item);
            return item;
        }

        public T Peek()
        {
            return queue.Peek();
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queue.GetEnumerator();
        }
    }
}
