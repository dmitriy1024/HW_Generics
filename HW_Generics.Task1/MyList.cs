using System;
using System.Collections;
using System.Collections.Generic;

namespace HW_Generics.Task1
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] _values;
        private int _count = 0;
        private const int _initialCapacity = 5;

        public int Count
        {
            get { return _count; }
        }

        public MyList()
        {
            _values = new T[_initialCapacity];
        }

        public T this [int index]
        {
            get
            {
                if (index < 0 || index > _count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _values[index];
                }                    
            }
        }

        public void Add(T item)
        {   
            if(_count + 1 > _values.Length)
            {
                T[] newArray = new T[_values.Length * 2];
                Array.Copy(_values, newArray, _count);

                _values = newArray;               
            }

            _values[_count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException("Index does not exist.");
            }
            else if(_values.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Collection is empty.");
            }
            else 
            {
                Array.Copy(_values, index + 1, _values, index, _count - index - 1);
                _values[--_count] = default(T);

                if (_count < _values.Length / 2 && _values.Length / 2 >= _initialCapacity)
                {
                    T[] newArray = new T[_values.Length / 2];
                    Array.Copy(_values, newArray, _count);

                    _values = newArray;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
