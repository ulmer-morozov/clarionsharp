using System;
using System.Collections.Generic;

namespace ClarionSharp
{
    public struct ClarionKeyRecord
    {
        private readonly Byte _numComps; //number of components for key
        private readonly char[] _keyName;//Char16; name of this key
        private readonly string _keyNameString;
        private readonly Byte _compType;   //type of composite
        private readonly Byte _compLen; //length of composite
        private readonly IEnumerable<ClarionKeyRecordItem> _items; 

        public ClarionKeyRecord(byte numComps, char[] keyName, byte compType, byte compLen, IEnumerable<ClarionKeyRecordItem> items)
            : this()
        {
            _numComps = numComps;
            _keyName = keyName;
            _keyNameString = new string(_keyName);
            _compType = compType;
            _compLen = compLen;
            _items = items;
        }

        public byte NumComps
        {
            get { return _numComps; }
        }

        public char[] KeyName
        {
            get { return _keyName; }
        }

        public string KeyNameString
        {
            get { return _keyNameString; }
        }

        public byte CompType
        {
            get { return _compType; }
        }

        public byte CompLen
        {
            get { return _compLen; }
        }

        public IEnumerable<ClarionKeyRecordItem> Items
        {
            get { return _items; }
        }
    }
}