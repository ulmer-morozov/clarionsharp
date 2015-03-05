using System.IO;

namespace ClarionSharp
{
    public static class ClarionHeaderReader
    {

        public static ClarionHeader ReadClarionHeader(this BinaryReader reader)
        {
            var fileSig = reader.ReadUInt16();
            var sfAtr = reader.ReadUInt16();
            //
            var numKeys = reader.ReadByte();
            var numRecs = reader.ReadUInt32();
            var numDels = reader.ReadUInt32();
            var numFlds = reader.ReadUInt16();
            var numPics = reader.ReadUInt16();
            var numArrs = reader.ReadUInt16();
            //
            var recLen = reader.ReadUInt16();
            //
            var offset = reader.ReadUInt32();
            var logEof = reader.ReadUInt32();
            var logBof = reader.ReadUInt32();
            var freeRec = reader.ReadUInt32();
            //
            var recName = reader.ReadChars(12);
            var memName = reader.ReadChars(12);
            var filPrefx = reader.ReadChars(3);
            var recPrefx = reader.ReadChars(3);
            //
            var memoLen = reader.ReadUInt16();
            var memoWid = reader.ReadUInt16();
            //
            var lockCont = reader.ReadUInt32();
            //
            var chgTime = reader.ReadUInt32();
            var chgDate = reader.ReadUInt32();
            //
            var checkSum = reader.ReadUInt16();
            var header = new ClarionHeader(
                fileSig, sfAtr,
                numKeys, numRecs, numDels, numFlds, numPics, numArrs,
                recLen,
                offset, logEof, logBof, freeRec,
                recName, memName, filPrefx, recPrefx,
                memoLen, memoWid,
                lockCont,
                chgTime, chgDate,
                checkSum
                );
            return header;
        }


    }
}