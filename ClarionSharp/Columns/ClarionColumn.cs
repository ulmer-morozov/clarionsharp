using System.Collections.Generic;

namespace ClarionSharp.Columns
{
    public abstract class ClarionColumn<T> : IClarionColumn<T>
    {
        private readonly string _name;
        private readonly IList<T> _values;

        protected ClarionColumn(string name)
        {
            _name = name;
            _values = new List<T>();
        }

        public IList<T> Values
        {
            get { return _values; }
        }

        public string Name
        {
            get { return _name; }
        }

        public void Add(T value)
        {
            _values.Add(value);
        }

        public object GetValueAt(int index)
        {
            return _values[index];
        }

        public int Count
        {
            get { return _values.Count; }
        }

    }
}