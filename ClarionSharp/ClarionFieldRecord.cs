using System;

namespace ClarionSharp
{
    public struct ClarionFieldRecord
    {
        private readonly Byte _fldType;// type of field
        private readonly char[] _fldName;//Char16; name of field
        private readonly string _fldNameString;
        private readonly string _fieldNamePrefix;
        private readonly ushort _fOffset;//offset into record
        private readonly ushort _length;//length of field
        private readonly Byte _decSig;//significance for decimals
        private readonly Byte _decDec;//number of decimal places
        private readonly ushort _arrNum;//array number
        private readonly ushort _picNum;//picture number

        public const int PrefixLength = 3;
        public const int PrefixWithDotesLength = PrefixLength + 1;


        public ClarionFieldRecord(byte fldType, char[] fldName, ushort fOffset, ushort length, byte decSig, byte decDec, ushort arrNum, ushort picNum)
            : this()
        {
            _fldType = fldType;
            _fldName = fldName;
            _fOffset = fOffset;
            _length = length;
            _decSig = decSig;
            _decDec = decDec;
            _arrNum = arrNum;
            _picNum = picNum;
            //
            _fldNameString = new string(_fldName).Trim();
            if (_fldNameString.Length <= PrefixWithDotesLength)
                return;
            //read prefix
            _fieldNamePrefix = _fldNameString.Substring(0, PrefixLength);
            _fldNameString = _fldNameString.Substring(PrefixWithDotesLength);
        }

        public byte FldType
        {
            get { return _fldType; }
        }

        public char[] FldName
        {
            get { return _fldName; }
        }

        public ushort FOffset
        {
            get { return _fOffset; }
        }

        public ushort Length
        {
            get { return _length; }
        }

        public byte DecSig
        {
            get { return _decSig; }
        }

        public byte DecDec
        {
            get { return _decDec; }
        }

        public ushort ArrNum
        {
            get { return _arrNum; }
        }

        public ushort PicNum
        {
            get { return _picNum; }
        }

        public string FldNameString
        {
            get { return _fldNameString; }
        }

        public ClarionFieldType Type
        {
            get
            {
                switch (FldType)
                {
                    case 1:
                        return ClarionFieldType.Long;
                    case 2:
                        return ClarionFieldType.Real;
                    case 3:
                        return ClarionFieldType.String;
                    case 4:
                        return ClarionFieldType.Picture;
                    case 5:
                        return ClarionFieldType.Byte;
                    case 6:
                        return ClarionFieldType.Short;
                    case 7:
                        return ClarionFieldType.Group;
                    case 8:
                        return ClarionFieldType.Decimal;
                    default:
                        return ClarionFieldType.Unknown;
                }
            }
        }

        public bool IsArray
        {
            get { return ArrNum > 0; }
        }

        public bool IsNotArray
        {
            get { return !IsArray; }
        }
    }
}