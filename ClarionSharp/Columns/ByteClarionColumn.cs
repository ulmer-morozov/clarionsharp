using System;

namespace ClarionSharp.Columns
{
    public class ByteClarionColumn : ClarionColumn<byte>, IClarionColumn
    {
        public ByteClarionColumn(string name) : base(name)
        {
        }

        public void AddBinaryValue(byte[] bytes)
        {
            if (bytes.Length != 1)
                throw new InvalidCastException("Невозможно преобразовать массив битов длиной " + bytes.Length + " в структуру byte");
            //
            var value = bytes[0];
            Add(value);
        }
    }
}