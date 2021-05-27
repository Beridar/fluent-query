using System.Collections.Generic;
using System.Linq;

namespace FluentQuery
{
    public interface ISelectedDatabase : IQueryBuilder
    {
        bool Exists { get; }
        public string Database { get; set; }
    }

    public class SelectedDatabase : ISelectedDatabase
    {
        public IExecutableQuery Query(string query)
        {
            throw new System.NotImplementedException();
        }

        public IExecutableQuery WithParameters(object parameters)
        {
            if (parameters == null)
            {
                QueryParameters = null;
                return ???;
            }

            QueryParameters = parameters is IDictionary<string, object> dictionaryParameters
                ? dictionaryParameters
                : ConvertObjectToDictionary(parameters);

            return ???;
        }

        private IDictionary<string, object> ConvertObjectToDictionary(object parameters)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists { get; }

        public string Database { get; set; }

        public IDictionary<string, object> QueryParameters { get; private set; }
    }
}
