using System.IO;

namespace ClarionSharp
{
    public static class ClarionFieldRecordReader
    {

        public static ClarionFieldRecord ReadClarionFieldRecord(this BinaryReader reader)
        {
            var fldType = reader.ReadByte();
            var fldName = reader.ReadChars(16);
            //
            var fOffset = reader.ReadUInt16();
            var length = reader.ReadUInt16();
            //
            var decSig = reader.ReadByte();
            var decDec = reader.ReadByte();
            //
            var arrNum = reader.ReadUInt16();
            var picNum = reader.ReadUInt16();
            //
            var field = new ClarionFieldRecord(
                fldType,
                fldName,

                fOffset,
                length,

                decSig,
                decDec,

                arrNum,
                picNum
                );
            return field;
        }


    }
}