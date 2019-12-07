using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class EntitiesCounter<T> : ICollection<T>
    {
        Dictionary<T, int> words = new Dictionary<T, int>();

        public int this[T key]
        {
            get
            {
                return words[key];
            }
        }

        public int Count
        {
            get
            {
                return words.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            try
            {
                words[item]++;
            }
            catch(KeyNotFoundException ex)
            {
                words.Add(item, 1);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            words.Clear();
        }

        public bool Contains(T item)
        {
            return words.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return words.Keys.GetEnumerator();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach(KeyValuePair<T, int> item in words)
            {
                builder.AppendLine($"{item.Key}: {item.Value}");
            }

            return builder.ToString();
        }
    }
}
