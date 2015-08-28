using System;
using System.Collections.Generic;

namespace HW_Generics.Task2
{
    class MyDictionary <TKey, TValue>
    {
        private TKey[][] _keys;
        private TValue[][] _values;

        private int _count;
        private int _maxCapacity = _initCapacity;

        private const int _initCapacity = 20;
        private const double _loadFactor = 0.72;//значение коэф. заполнения рекомендуемое майкрософтом как оптимальное

        private int ArraysSize
        {
            get { return (int)(_maxCapacity / _loadFactor); }
        }

        #region Public Properties

        public int Count
        {
            get { return _count; }
        }

        public TKey[] Keys
        {
            get
            {
                var list = new List<TKey>(_count);
                for (int i = 0; i < ArraysSize; i++)
                {
                    if (_keys[i] != null)
                    {
                        for (int j = 0; j < _keys[i].Length; j++)
                        {
                            list.Add(_keys[i][j]);
                        }
                    }
                }

                return list.ToArray();
            }
        }

        public TValue[] Values
        {
            get
            {
                var list = new List<TValue>(_count);
                for (int i = 0; i < ArraysSize; i++)
                {
                    if (_values[i] != null)
                    {
                        for (int j = 0; j < _values[i].Length; j++)
                        {
                            list.Add(_values[i][j]);
                        }
                    }
                }

                return list.ToArray();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                else if (!Contains(key))
                {
                    throw new ArgumentException("Key does not exist");
                }
                else
                {
                    int keyIndex = Hash(key);

                    for (int i = 0; i < _keys[keyIndex].Length; i++)
                    {
                        if (_keys[keyIndex][i].Equals(key))
                        {
                            return _values[keyIndex][i];
                        }
                    }

                    throw new ArgumentException();
                }
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                else if (!Contains(key))
                {
                    Add(key, value);
                }
                else
                {
                    int keyIndex = Hash(key);

                    for (int i = 0; i < _keys[keyIndex].Length; i++)
                    {
                        if (_keys[keyIndex][i].Equals(key))
                        {
                            _values[keyIndex][i] = value;
                            return;
                        }
                    }

                    throw new ArgumentException();
                }
            }
        }
        #endregion

        public MyDictionary()
        {
            int arrSize = (int)(_maxCapacity / _loadFactor);
            _keys = new TKey [arrSize][];
            _values = new TValue [arrSize][];
        }

        public void Add(TKey key, TValue value)
        {   
            if (_count + 1 > _maxCapacity)
            {
                IncMaxCapacity();
            }

            AddToArrays(key, value);
        }

        public void Remove(TKey key)
        {
            if (_count - 1 < _maxCapacity / 2 && _maxCapacity / 2 >= _initCapacity)
            {
                DecreaseMaxCapacity();
            }

            RemoveFromArrays(key);
        }

        private void IncMaxCapacity()
        {
            TKey[][] oldKeys = _keys;
            TValue[][] oldValues = _values;

            _maxCapacity *= 2;

            _keys = new TKey[ArraysSize][];
            _values = new TValue[ArraysSize][];
            _count = 0;

            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (oldKeys[i] != null)
                {
                    for (int j = 0; j < oldKeys[i].Length; j++)
                    {
                        AddToArrays(oldKeys[i][j], oldValues[i][j]);
                    }
                }
            }
        }

        private void DecreaseMaxCapacity()
        {
            TKey[][] oldKeys = _keys;
            TValue[][] oldValues = _values;

            _maxCapacity /= 2;

            _keys = new TKey[ArraysSize][];
            _values = new TValue[ArraysSize][];
            _count = 0;

            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (oldKeys[i] != null)
                {
                    for (int j = 0; j < oldKeys[i].Length; j++)
                    {
                        AddToArrays(oldKeys[i][j], oldValues[i][j]);
                    }
                }
            }
        }

        private void AddToArrays(TKey key, TValue value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentNullException();
            }
            else if (Contains(key))
            {
                throw new ArgumentException("Item with the same index was added.");
            }
            else
            {
                int keyIndex = Hash(key);

                if(_keys[keyIndex] == null)
                {
                    _keys[keyIndex] = new TKey[1];
                    _keys[keyIndex][0] = key;

                    _values[keyIndex] = new TValue[1];
                    _values[keyIndex][0] = value;
                }
                else
                {
                    int newLength = _keys[keyIndex].Length + 1;

                    TKey[] innerKeys = new TKey[newLength];
                    TValue[] innerValues = new TValue[newLength];

                    Array.Copy(_keys[keyIndex], innerKeys, newLength - 1);
                    Array.Copy(_values[keyIndex], innerValues, newLength - 1);

                    innerKeys[newLength - 1] = key;
                    innerValues[newLength - 1] = value;

                    _keys[keyIndex] = innerKeys;
                    _values[keyIndex] = innerValues;
                }

                _count++;
            }            
        }

        private void RemoveFromArrays(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            else if (!Contains(key))
            {
                throw new ArgumentException("Key does not exist.");
            }
            else
            {
                int index = Hash(key);

                if (_keys[index].Length == 1)
                {
                    _keys[index] = null;
                    _values[index] = null;
                    _count--;
                }
                else
                {
                    for (int i = 0; i < _keys[index].Length; i++)
                    {
                        if (key.Equals(_keys[index][i]))
                        {
                            TKey[] newKeysArr = new TKey[_keys[index].Length - 1];
                            TValue[] newValuesArr = new TValue[_keys[index].Length - 1];

                            Array.Copy(_keys[index], newKeysArr, i);
                            Array.Copy(_values[index], newValuesArr, i);

                            Array.Copy(_keys[index], i + 1, newKeysArr, i, _keys[index].Length - i - 1);
                            Array.Copy(_values[index], i + 1, newValuesArr, i, _values[index].Length - i - 1);

                            _keys[index] = newKeysArr;
                            _values[index] = newValuesArr;

                            _count--;
                            break;
                        }
                    }
                }
            }
        }

        private int Hash(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % ArraysSize;
        }

        private bool Contains(TKey key)
        {
            if(key == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                int keyIndex = Hash(key);
                if (_keys[keyIndex] == null)
                {
                    return false;
                }
                else
                {
                    foreach (var item in _keys[keyIndex])
                    {
                        if(item.Equals(key))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }
    }
}
