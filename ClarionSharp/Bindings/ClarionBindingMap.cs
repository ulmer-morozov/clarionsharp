using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClarionSharp.Bindings
{
    public class ClarionBindingMap<T>
    {
        private readonly IDictionary<string, ClarionBinding<T>> _bindings;

        public ClarionBindingMap()
        {
            _bindings = new Dictionary<string, ClarionBinding<T>>(); ;
        }

        public ClarionBindingMap<T> Map(string columnName, Expression<Func<T, object>> selector)
        {
            var binding = new ClarionBinding<T>(columnName, selector);
            _bindings.Add(columnName, binding);
            return this;
        }

        public IDictionary<string, ClarionBinding<T>> Bindings
        {
            get { return _bindings; }
        }
    }
}