using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        protected static int _minCapacity = 8;
        protected T[] _array;
        protected int _length = 0;
        protected int _position = -1;

        public T this[int index]
        {
            get
            {
                if(index < 0)
                {
                    index += _length;
                }

                if (index >= _length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }

            set
            {
                if (index < 0)
                {
                    index += _length;
                }

                if (index >= _length)
                {
                    throw new IndexOutOfRangeException();
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

            set
            {
                T[] newArray = new T[value];
                try
                {
                    for (int i = 0; i < value; i++)
                    {
                        newArray[i] = _array[i];
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    
                }

                if (value < _array.Length)
                    _length = newArray.Length;

                _array = newArray;

                
            }
        }

        public T Current
        {
            get
            {
                return _array[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _array[_position];
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

        protected void Expand(int newElementsCount = 1)
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
            CycledDynamicArray<T> cda = (items as CycledDynamicArray<T>);

            int count = (cda != null ? count = cda.Count() : items.Count());

            T[] arrayToAdd = new T[count];

            int j = 0;
            foreach (T item in items)
            {
                arrayToAdd[j++] = item;
                if(j == count)
                {
                    break;
                }
            }
            
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
                    return true;
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

        public bool Insert(T item, int index)
        {
            if(index > _length)
            {
                throw new ArgumentOutOfRangeException();
            }

            try
            {
                Add(item);
                T tempItem;

                for (int i = _length - 1; i > index; i--)
                {
                    tempItem = _array[i - 1];
                    _array[i - 1] = _array[i];
                    _array[i] = tempItem;
                }
            }
            catch(Exception)
            {
                return false;
            }
            
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator() as IEnumerator<T>;
        }

        public object Clone()
        {
            T[] newArray = new T[_array.Length];

            for(int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            return new DynamicArray<T> {_array = newArray, _length = _length };
        }

        public T[] ToArray()
        {
            T[] newArray = new T[_length];

            for(int i = 0; i < _length; i++)
            {
                newArray[i] = _array[i];
            }

            return newArray;
        }

        public static implicit operator T [] (DynamicArray<T> array)
        {
            T[] newArray = new T[array._length];

            for (int i = 0; i < array._length; i++)
            {
                newArray[i] = array._array[i];
            }

            return newArray;
        }

        public bool MoveNext()
        {
            return (_position++ < _length - 1);
            
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
