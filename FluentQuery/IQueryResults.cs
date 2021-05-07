using System.Collections.Generic;

namespace FluentQuery
{
    public interface IQueryResults : IEnumerable<IDictionary<string, string>>
    {
        IEnumerable<IDictionary<string, string>> Results { get; }
        IEnumerable<T> ResultsAs<T>();
    }
}