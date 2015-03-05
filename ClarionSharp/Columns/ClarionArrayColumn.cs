namespace ClarionSharp.Columns
{
    public abstract class ClarionArrayColumn<T> : ClarionColumn<T[]>, IClarionColumn
        where T : struct
    {
        protected ClarionArrayColumn(string name)
            : base(name)
        {
        }

        public void AddBinaryValue(byte[] bytes)
        {
            var sizeInBytes = GetSizeInBytes();
            if (bytes.Length % sizeInBytes != 0)
            {
                var text = string.Format("Невозможно исходную последовательность {0} битов длиной преобразовать в тип {1}", bytes.Length, typeof(T));
                throw new System.InvalidCastException(text);
            }
            var count = bytes.Length / sizeInBytes;
            var values = new T[count];
            for (var i = 0; i < count; i++)
            {
                var value = Convert(bytes, i * sizeInBytes);
                values[i] = value;
            }
            Add(values);
        }

        protected abstract int GetSizeInBytes();
        protected abstract T Convert(byte[] bytes, int offset);
    }
}