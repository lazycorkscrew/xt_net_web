using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    static class CycledDynamicArrayExtension
    {
        public static int Count<T>(this CycledDynamicArray<T> items)
        {
            int c = 0;
            items.isEndless = false;
            var e = items.GetEnumerator();
            {
                while (e.MoveNext())
                    c++;
            }
            items.isEndless = true;
            return c;
        }
    }

    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>, IEnumerator
    {
        public bool isEndless = true;

        new object Current
        {
            get
            {
                return _array[_position];
            }
        }

        public CycledDynamicArray(IEnumerable<T> items)
        {
            _array = items.ToArray();
            _length = _array.Length;
            Expand();
        }

        public new bool MoveNext()
        {
            if(_position >= _length-1)
            {
                if (isEndless)
                {
                    Reset();
                }
                else
                {
                    return false;
                }
            }

            _position++;
            return true;
        }

        public new IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this as IEnumerator<T>;
        }
    }
}
