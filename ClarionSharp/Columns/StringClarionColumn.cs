using System.Text;

namespace ClarionSharp.Columns
{
    public class StringClarionColumn : ClarionColumn<string>, IClarionColumn
    {
        private readonly Encoding _encoding;

        public StringClarionColumn(string columnName, Encoding encoding)
            : base(columnName)
        {
            _encoding = encoding;
        }

        public void AddBinaryValue(byte[] bytes)
        {
            var stringValue = _encoding.GetString(bytes).Trim();
            Add(stringValue);
        }

    }
}