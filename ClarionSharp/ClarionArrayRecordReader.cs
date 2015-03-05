using System.Collections.Generic;
using System.IO;

namespace ClarionSharp
{
    public static class ClarionArrayRecordReader
    {
        public static ClarionArrayRecord ReadClarionArrayRecord(this BinaryReader reader)
        {
            //record
            var numDim = reader.ReadUInt16();
            var totDim = reader.ReadUInt16();
            var elmSiz = reader.ReadUInt16();
            //
            var items = new List<ClarionArrayRecordItem>();
            for (var i = 0; i < totDim; i++)
            {
                var maxDim = reader.ReadUInt16();
                var lenDim = reader.ReadUInt16();
                var item = new ClarionArrayRecordItem(maxDim, lenDim);
                items.Add(item);
            }
            var arrayRecord = new ClarionArrayRecord(
                numDim,
                totDim,
                elmSiz,
                items
                );
            return arrayRecord;
        }
    }
}