using System.IO;

namespace ClarionSharp
{
    public static class ClarionPictureRecordReader
    {
        public static ClarionPictureRecord ReadClarionPictureRecord(this BinaryReader reader)
        {
            var picLen = reader.ReadUInt16();
            if (picLen>256)
            {
                picLen = 256;
            }
            var picChars = picLen==0 ? new char[0] : reader.ReadChars(picLen);
            var picture = new ClarionPictureRecord(picLen, picChars);
            return picture;
        }
    }
}