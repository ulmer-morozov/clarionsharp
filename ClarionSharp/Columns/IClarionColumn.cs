using System.Collections.Generic;

namespace ClarionSharp.Columns
{
    public interface IClarionColumn<T>
    {
        IList<T> Values { get; }
        void Add(T value);
        object GetValueAt(int index);
    }

    public interface IClarionColumn
    {
        void AddBinaryValue(byte[] bytes);
        int Count { get; }
        string Name { get; }
        object GetValueAt(int index);
    }
}
