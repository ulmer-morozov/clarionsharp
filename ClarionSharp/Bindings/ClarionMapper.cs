using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ClarionSharp.Columns;

namespace ClarionSharp.Bindings
{
    public class ClarionMapper
    {
        public T MapRecord<T>(ClarionBindingMap<T> map, IList<IClarionColumn> columns)
            where T : class ,new()
        {
            if (columns.Any(x => x.Count != 1))
                throw new Exception("Исходный массив данных содержит более одной записи и не может быть приведен к одному объекту");
            //
            var record = MapRecords(map, columns).Single();
            return record;
        }

        public IEnumerable<T> MapRecords<T>(ClarionBindingMap<T> map, IList<IClarionColumn> columns)
            where T : new()
        {
            var recordsCount = columns.Select(x => x.Count).Distinct().Single();
            var mappedRecords = new List<T>();
            //
            for (var i = 0; i < recordsCount; i++)
            {
                var mappedRecord = new T();
                foreach (var column in columns)
                {
                    var binding = map.Bindings[column.Name];
                    var value = column.GetValueAt(i);

                    var memberExpression = GetMemberExpression(binding.FieldSelector.Body);


                    var prop = (PropertyInfo)(memberExpression.Member);
                    prop.SetValue(mappedRecord, value, null);
                }
                mappedRecords.Add(mappedRecord);
            }
            return mappedRecords;
        }

        private static MemberExpression GetMemberExpression(Expression body)
        {
            var candidates = new Queue<Expression>();
            candidates.Enqueue(body);
            while (candidates.Count > 0)
            {
                var expr = candidates.Dequeue();
                if (expr is MemberExpression)
                {
                    return ((MemberExpression)expr);
                }
                else if (expr is UnaryExpression)
                {
                    candidates.Enqueue(((UnaryExpression)expr).Operand);
                }
                else if (expr is BinaryExpression)
                {
                    var binary = expr as BinaryExpression;
                    candidates.Enqueue(binary.Left);
                    candidates.Enqueue(binary.Right);
                }
                else if (expr is MethodCallExpression)
                {
                    var method = expr as MethodCallExpression;
                    foreach (var argument in method.Arguments)
                    {
                        candidates.Enqueue(argument);
                    }
                }
                else if (expr is LambdaExpression)
                {
                    candidates.Enqueue(((LambdaExpression)expr).Body);
                }
            }

            return null;
        }
    }
}