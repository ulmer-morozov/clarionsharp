using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClarionSharp.Bindings;
using ClarionSharp.Columns;

namespace ClarionSharp
{
    public class ClarionDatabase : IDisposable
    {
        private readonly Stream _stream;
        private readonly BinaryReader _reader;

        private ClarionHeader _header;
        private IList<ClarionFieldRecord> _fields;
        private IList<ClarionKeyRecord> _keys;
        private IList<ClarionPictureRecord> _pictures;
        private IList<ClarionArrayRecord> _arrayRecords;

        const int RecDataLengthInBytes = 5;

        public ClarionDatabase(string filePath)
        {
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _reader = new BinaryReader(_stream);
            //
            ReadHeader();
            ReadFields();
            ReadKeys();
            ReadPictures();
            ReadArrayRecords();
            CurrentRecordIndex = 0;
        }

        public uint CurrentRecordIndex { get; private set; }

        public IList<IClarionColumn> ReadRecords(uint recordsCount)
        {
            var columns = _fields.Select(CreateColumnForField).ToList();
            var startRecordPosition = CurrentRecordIndex;
            var endRecordPosition = startRecordPosition + recordsCount;
            if (endRecordPosition > _header.NumRecs)
            {
                endRecordPosition = _header.NumRecs;
            }
            //собираем значения
            while (CurrentRecordIndex < endRecordPosition)
            {
                SkipUnnecessaryRecData();
                for (var fieldIndex = 0; fieldIndex < _fields.Count; fieldIndex++)
                {
                    var field = _fields[fieldIndex];
                    var column = columns[fieldIndex];
                    byte[] bytes;
                    if (field.IsNotArray)
                    {
                        bytes = _reader.ReadBytes(field.Length);
                    }
                    else
                    {
                        var arrayRecord = _arrayRecords[field.ArrNum - 1];
                        bytes = _reader.ReadBytes(arrayRecord.ElmSiz);
                    }
                    column.AddBinaryValue(bytes);
                }
                CurrentRecordIndex++;
            }
            return columns;
        }

        public IList<IClarionColumn> ReadAllRecords()
        {
            return ReadRecords(_header.NumRecs);
        }

        public IList<IClarionColumn> ReadRecord()
        {
            return ReadRecords(1);
        }

        public T ReadRecord<T>(ClarionBindingMap<T> map)
            where T : new()
        {
            var items = ReadRecords(map, 1);
            var item = items.Single();
            return item;
        }

        public IList<T> ReadRecords<T>(ClarionBindingMap<T> map, uint recordCount)
            where T : new()
        {
            var records = ReadRecords(1);
            var mapper = new ClarionMapper();
            var items = mapper.MapRecords(map, records);
            return items;
        }

        public IList<T> ReadAllRecords<T>(ClarionBindingMap<T> map)
            where T : new()
        {
            return ReadRecords<T>(map, _header.NumRecs);
        }

        #region Helpers

        private void ReadHeader()
        {
            _header = _reader.ReadClarionHeader();
        }

        private void ReadFields()
        {
            _fields = new List<ClarionFieldRecord>();
            for (var i = 0; i < _header.NumFields; i++)
            {
                var field = _reader.ReadClarionFieldRecord();
                _fields.Add(field);
            }
        }

        private void ReadKeys()
        {
            _keys = new List<ClarionKeyRecord>();
            for (var i = 0; i < _header.NumKeys; i++)
            {
                var key = _reader.ReadClarionKeyRecord();
                _keys.Add(key);
            }
        }

        private void ReadPictures()
        {
            _pictures = new List<ClarionPictureRecord>();
            for (var i = 0; i < _header.NumPics; i++)
            {
                var picture = _reader.ReadClarionPictureRecord();
                _pictures.Add(picture);
            }
        }

        private void ReadArrayRecords()
        {
            _arrayRecords = new List<ClarionArrayRecord>();
            for (var i = 0; i < _header.NumArrs; i++)
            {
                var arrayRecord = _reader.ReadClarionArrayRecord();
                _arrayRecords.Add(arrayRecord);
            }
        }

        private void SkipUnnecessaryRecData()
        {
            _reader.BaseStream.Seek(RecDataLengthInBytes, SeekOrigin.Current);
        }

        private static IClarionColumn CreateColumnForField(ClarionFieldRecord field)
        {
            IClarionColumn column;
            if (field.IsNotArray)
            {
                switch (field.Type)
                {
                    case ClarionFieldType.String:
                        column = new StringClarionColumn(field.FldNameString, Encoding.ASCII);
                        break;

                    case ClarionFieldType.Short:
                        column = new ShortClarionColumn(field.FldNameString);
                        break;

                    default:
                        throw new NotImplementedException("Не могу создать столбец для этого типа! " + field.Type + " | " + field.FldType);

                }
                return column;
            }
            //Array
            switch (field.Type)
            {
                case ClarionFieldType.Short:
                    column = new ShortArrayClarionColumn(field.FldNameString);
                    break;

                case ClarionFieldType.Byte:
                    column = new ByteArrayClarionColumn(field.FldNameString);
                    break;

                default:
                    throw new NotImplementedException("Не могу создать столбец - массив для этого типа! " + field.Type + " | " + field.FldType);

            }
            return column;
        }

        #endregion

        public void Dispose()
        {
            _reader.Dispose();
            _stream.Dispose();
        }
    }
}