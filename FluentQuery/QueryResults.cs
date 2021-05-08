using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentQuery
{
    public class QueryResults : IQueryResults
    {
        private readonly IEnumerable<IDictionary<string, string>> _results;

        public QueryResults(IEnumerable<IDictionary<string, string>> results)
        {
            _results = results;
        }

        public IEnumerator<IDictionary<string, string>> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<IDictionary<string, string>> Results => _results;

        public IEnumerable<T> ResultsAs<T>()
            where T : new()
        {
            var propertiesToMap = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return _results.Select(s =>
            {
                var resultObject = new T();

                foreach(var property in propertiesToMap)
                    if (s.ContainsKey(property.Name))
                        SetValue(property, resultObject, s);

                return resultObject;
            });
        }

        private static void SetValue<T>(PropertyInfo property, T resultObject, IDictionary<string, string> s)
            where T : new()
        {
            object valueToSet = s[property.Name];

            if (property.PropertyType == typeof(int))
                valueToSet = Convert.ToInt32(valueToSet);

            property.SetValue(resultObject, valueToSet);
        }
    }
}
