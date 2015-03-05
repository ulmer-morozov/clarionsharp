using System.Collections.Generic;

namespace ClarionSharp
{
    public struct ClarionArrayRecord
    {
        private readonly ushort _numDim;//dims for current field
        private readonly ushort _totDim;//total number of dims for field
        private readonly ushort _elmSiz;//total size of current field Array Of TArrayPart's   
        private readonly IEnumerable<ClarionArrayRecordItem> _items;

        public ClarionArrayRecord(ushort numDim, ushort totDim, ushort elmSiz, IEnumerable<ClarionArrayRecordItem> items)
            : this()
        {
            _numDim = numDim;
            _totDim = totDim;
            _elmSiz = elmSiz;
            _items = items;
        }

        public ushort NumDim
        {
            get { return _numDim; }
        }

        public ushort TotDim
        {
            get { return _totDim; }
        }

        public ushort ElmSiz
        {
            get { return _elmSiz; }
        }

        public IEnumerable<ClarionArrayRecordItem> Items
        {
            get { return _items; }
        }
    }
}