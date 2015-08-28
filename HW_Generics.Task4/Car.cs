using System;

namespace HW_Generics.Task4
{
    class Car
    {
        private string _name;
        private int _manufactYear;

        public string Name
        {
            get { return _name; }
        }

        public int ManufactYear
        {
            get { return _manufactYear; }
        }

        public Car(string name, int manufactYear)
        {
            if(name == null || manufactYear < 1800 || manufactYear > DateTime.Now.Year)
            {
                throw new ArgumentException();
            }
            else
            {
                _name = name;
                _manufactYear = manufactYear;
            }
        }
    }
}
