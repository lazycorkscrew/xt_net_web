using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private int _minCapacity = 8;
        private T[] _array;
        private int _length = 0;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _array[index];
            }

            set
            {
                if (index < 0 || index >= _length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public DynamicArray()
        {
            _array = new T[_minCapacity];
        }

        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> array)
        {
            _array = array.ToArray();
            _length = _array.Length;
        }

        public void Remone(int index)
        {

            _length--;
        }

        private void Expand(int newElementsCount = 1)
        {
            int newCapacity = _minCapacity;

            while(newCapacity < _array.Length + newElementsCount)
            {
                newCapacity *= 2;
            }

            T[] newArray = new T[newCapacity];

            if (_array.Length < newCapacity)
            {
                for(int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }
            }

            _array = newArray;
        }

        public void Add(T item)
        {
            if(_length >= _array.Length)
            {
                Expand();
            }

            _array[_length++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            T[] arrayToAdd = items.ToArray();
            int arrayToAddLength = arrayToAdd.Length;
            
            Expand(arrayToAddLength);

            for(int i = 0; i < arrayToAddLength; i++)
            {
                _array[_length++] = arrayToAdd[i];
            }
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < _length; i++)
            {
                if(_array[i].Equals(item))
                {
                    RemoveAt(i);
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            T item = _array[index];

            for(int i = index; i < _length; i++)
            {
                _array[i] = _array[i + 1];
            }

            _length--;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}
