using System;
using HW_Generics.Task1;

namespace HW_Generics.Task4
{
    class CarCollection<T> where T : Car
    {
        private MyList<T> _cars = new MyList<T>();

        public int Count
        {
            get { return _cars.Count; }
        }

        public T this [int index]
        {
            get
            {
                if(index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _cars[index];
                }
            }
        }

        public void Add(T car)
        {
            if (car == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _cars.Add(car);
            }
        }

        public void Clear()
        {
            _cars = new MyList<T>();
        }
    }
}
