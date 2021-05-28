using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentQuery
{
    public interface IQueryResults : IEnumerable<IDictionary<string, string>>
    {
        IEnumerable<IDictionary<string, string>> Results { get; }

        IEnumerable<T> ResultsAs<T>()
            where T : new();
    }

    public class QueryResults : IQueryResults
    {
        private readonly IEnumerable<IDictionary<string, object>> _results;

        public QueryResults(IEnumerable<IDictionary<string, object>> results)
        {
            _results = results;
        }

        private IEnumerable<IDictionary<string, string>> ResultsWithStringValues()
        {
            foreach (var result in _results)
                yield return result.ToDictionary(k => k.Key,
                    k => k.Value?.ToString());
        }

        public IEnumerator<IDictionary<string, string>> GetEnumerator()
        {
            return ResultsWithStringValues().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<IDictionary<string, string>> Results => ResultsWithStringValues();

        public IEnumerable<T> ResultsAs<T>()
            where T : new()
        {
            var propertiesToMap = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return _results.Select(s =>
            {
                var resultObject = new T();

                foreach(var property in propertiesToMap)
                    if (s.ContainsKey(property.Name))
                        property.SetValue(resultObject, s[property.Name]);

                return resultObject;
            });
        }
    }
}
