using System.Collections;
using System.Collections.Generic;

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
        {
            throw new System.NotImplementedException();
        }
    }
}
