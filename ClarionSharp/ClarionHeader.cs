using System;

namespace ClarionSharp
{
    public struct ClarionHeader
    {
        private readonly ushort _fileSig;  //file signature
        private readonly ushort _sfAtr;// file attribute and status

        private readonly Byte _numKeys;//number of keys in file
        private readonly uint _numRecs; //number of records in file
        private readonly uint _numDels;//number of deleted records
        private readonly ushort _numFields;// number of fields
        private readonly ushort _numPics;// number of pictures
        private readonly ushort _numArrs;//number of array descriptors

        private readonly ushort _recLen;//record length (including record header)

        private readonly uint _offset;//start of data area
        private readonly uint _logEof;//logical end of file
        private readonly uint _logBof;//logical beginning of file
        private readonly uint _freeRec;//first usable deleted record

        private readonly char[] _recName;//Char 12; record name without prefix
        private readonly char[] _memName;//Char12; memo name without prefix
        private readonly char[] _filPrefx;//Char3; file name prefix
        private readonly char[] _recPrefx;//Char3; record name prefix

        private readonly string _recNameString;
        private readonly string _memNameString;
        private readonly string _filPrefxString;
        private readonly string _recPrefxString;

        private readonly ushort _memoLen;//size of memo
        private readonly ushort _memoWid;//column width of memo

        private readonly uint _lockCont;//Lock Count

        private readonly uint _chgTime;//time of last change
        private readonly uint _chgDate;//date of last change

        private readonly ushort _checkSum;//checksum for encrypt

        public ClarionHeader(ushort fileSig, ushort sfAtr, byte numKeys, uint numRecs, uint numDels, ushort numFlds, ushort numPics, ushort numArrs, ushort recLen, uint offset, uint logEof, uint logBof, uint freeRec, char[] recName, char[] memName, char[] filPrefx, char[] recPrefx, ushort memoLen, ushort memoWid, uint lockCont, uint chgTime, uint chgDate, ushort checkSum)
            : this()
        {
            _fileSig = fileSig;
            _sfAtr = sfAtr;
            _numKeys = numKeys;
            _numRecs = numRecs;
            _numDels = numDels;
            _numFields = numFlds;
            _numPics = numPics;
            _numArrs = numArrs;
            _recLen = recLen;
            _offset = offset;
            _logEof = logEof;
            _logBof = logBof;
            _freeRec = freeRec;
            _recName = recName;
            _memName = memName;
            _filPrefx = filPrefx;
            _recPrefx = recPrefx;
            _memoLen = memoLen;
            _memoWid = memoWid;
            _lockCont = lockCont;
            _chgTime = chgTime;
            _chgDate = chgDate;
            _checkSum = checkSum;
            //
            _recNameString = new string(_recName);
            _memNameString = new string(_memName);
            _filPrefxString = new string(_filPrefx);
            _recPrefxString = new string(_recPrefx);
        }

        public ushort FileSig
        {
            get { return _fileSig; }
        }

        public ushort SfAtr
        {
            get { return _sfAtr; }
        }

        public byte NumKeys
        {
            get { return _numKeys; }
        }

        public uint NumRecs
        {
            get { return _numRecs; }
        }

        public uint NumDels
        {
            get { return _numDels; }
        }

        public ushort NumFields
        {
            get { return _numFields; }
        }

        public ushort NumPics
        {
            get { return _numPics; }
        }

        public ushort NumArrs
        {
            get { return _numArrs; }
        }

        public ushort RecLen
        {
            get { return _recLen; }
        }

        public uint Offset
        {
            get { return _offset; }
        }

        public uint LogEof
        {
            get { return _logEof; }
        }

        public uint LogBof
        {
            get { return _logBof; }
        }

        public uint FreeRec
        {
            get { return _freeRec; }
        }

        public char[] RecName
        {
            get { return _recName; }
        }

        public char[] MemName
        {
            get { return _memName; }
        }

        public char[] FilPrefx
        {
            get { return _filPrefx; }
        }

        public char[] RecPrefx
        {
            get { return _recPrefx; }
        }

        public ushort MemoLen
        {
            get { return _memoLen; }
        }

        public ushort MemoWid
        {
            get { return _memoWid; }
        }

        public uint LockCont
        {
            get { return _lockCont; }
        }

        public uint ChgTime
        {
            get { return _chgTime; }
        }

        public uint ChgDate
        {
            get { return _chgDate; }
        }

        public ushort CheckSum
        {
            get { return _checkSum; }
        }

        public string RecNameString
        {
            get { return _recNameString; }
        }

        public string MemNameString
        {
            get { return _memNameString; }
        }

        public string FilPrefxString
        {
            get { return _filPrefxString; }
        }

        public string RecPrefxString
        {
            get { return _recPrefxString; }
        }
    }
}