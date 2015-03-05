using System;
using System.Linq.Expressions;

namespace ClarionSharp.Bindings
{
    public class ClarionBinding<T>
    {
        private readonly string _columnName;
        private readonly Expression<Func<T, object>> _fieldSelector;

        public ClarionBinding(string columnName, Expression<Func<T, object>> fieldSelector)
        {
            _columnName = columnName;
            _fieldSelector = fieldSelector;
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public Expression<Func<T, object>> FieldSelector
        {
            get { return _fieldSelector; }
        }
    }
}