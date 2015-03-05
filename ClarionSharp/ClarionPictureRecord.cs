namespace ClarionSharp
{
    public struct ClarionPictureRecord
    {
        private readonly ushort _picLen;
        private readonly char[] _picChars;//Char256; 
        private readonly string _pictureString;

        public ClarionPictureRecord(ushort picLen, char[] picChars)
            : this()
        {
            _picLen = picLen;
            _picChars = picChars;
            _pictureString = new string(_picChars);
        }

        public ushort PicLen
        {
            get { return _picLen; }
        }

        public char[] PicChars
        {
            get { return _picChars; }
        }

        public string PictureString
        {
            get { return _pictureString; }
        }
    }
}