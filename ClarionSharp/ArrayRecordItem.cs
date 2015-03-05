namespace ClarionSharp
{
    public struct ClarionArrayRecordItem
    {
        private readonly ushort _maxDim;//number of dims for array part
        private readonly ushort _lenDim;//length of field

        public ClarionArrayRecordItem(ushort maxDim, ushort lenDim) : this()
        {
            _maxDim = maxDim;
            _lenDim = lenDim;
        }

        public ushort MaxDim
        {
            get { return _maxDim; }
        }

        public ushort LenDim
        {
            get { return _lenDim; }
        }
    }
}