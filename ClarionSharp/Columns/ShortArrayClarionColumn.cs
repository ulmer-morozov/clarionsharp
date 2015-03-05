using System;

namespace ClarionSharp.Columns
{
    public class ShortArrayClarionColumn : ClarionArrayColumn<short>
    {
        public ShortArrayClarionColumn(string name) : base(name)
        {
        }

        protected override int GetSizeInBytes()
        {
            return sizeof(short);
        }

        protected override short Convert(byte[] bytes, int offset)
        {
            var value = BitConverter.ToInt16(bytes, offset);
            return value;
        }
    }
}