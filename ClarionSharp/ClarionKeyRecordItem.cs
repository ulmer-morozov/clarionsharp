using System;

namespace ClarionSharp
{
    public struct ClarionKeyRecordItem
    {
        private readonly Byte _fldType;//type of field
        private readonly ushort _fldNum; //field number
        private readonly ushort _elmOff;//record offset of this element
        private readonly Byte _elmLen;//length of element

        public ClarionKeyRecordItem(byte fldType, ushort fldNum, ushort elmOff, byte elmLen) : this()
        {
            _fldType = fldType;
            _fldNum = fldNum;
            _elmOff = elmOff;
            _elmLen = elmLen;
        }

        public byte FldType
        {
            get { return _fldType; }
        }

        public ushort FldNum
        {
            get { return _fldNum; }
        }

        public ushort ElmOff
        {
            get { return _elmOff; }
        }

        public byte ElmLen
        {
            get { return _elmLen; }
        }
    }
}