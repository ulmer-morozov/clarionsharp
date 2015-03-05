namespace ClarionSharp.Columns
{
    public class ByteArrayClarionColumn : ClarionArrayColumn<byte>
    {
        public ByteArrayClarionColumn(string name)
            : base(name)
        {
        }

        protected override int GetSizeInBytes()
        {
            return sizeof(byte);
        }

        protected override byte Convert(byte[] bytes, int offset)
        {
            var value = bytes[offset];
            return value;
        }
    }
}