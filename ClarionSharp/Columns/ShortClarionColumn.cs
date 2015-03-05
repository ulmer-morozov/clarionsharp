using System;

namespace ClarionSharp.Columns
{
    public class ShortClarionColumn : ClarionColumn<short>, IClarionColumn
    {
        public ShortClarionColumn(string name) : base(name)
        {
        }

        public void AddBinaryValue(byte[] bytes)
        {
            if (bytes.Length != 2)
                throw new InvalidCastException("Невозможно преобразовать массив битов длиной " + bytes.Length + " в структуру short");
            //
            var value = BitConverter.ToInt16(bytes, 0);
            Add(value);
        }
    }
}