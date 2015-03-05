using System.Collections.Generic;
using System.IO;

namespace ClarionSharp
{
    public static class ClarionKeyRecordReader
    {
        public static ClarionKeyRecord ReadClarionKeyRecord(this BinaryReader reader)
        {
            //record
            var numComps = reader.ReadByte();
            var keyName = reader.ReadChars(16);
            var compType = reader.ReadByte();
            var compLen = reader.ReadByte();
            //
            var items = new List<ClarionKeyRecordItem>();
            for (var i = 0; i < numComps; i++)
            {
                var fldType = reader.ReadByte();
                var fldNum = reader.ReadUInt16();
                var elmOff = reader.ReadUInt16();
                var elmLen = reader.ReadByte();
                //
                var keyItem = new ClarionKeyRecordItem(
                    fldType,
                    fldNum,
                    elmOff,
                    elmLen
                    );
                items.Add(keyItem);
            }
            var keyRecord = new ClarionKeyRecord(numComps, keyName, compType, compLen, items);
            return keyRecord;
        }
    }
}