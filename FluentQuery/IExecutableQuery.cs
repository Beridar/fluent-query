using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentQuery
{
    public interface IExecutableQuery : ISelectedDatabase
    {
        bool IsExecutable();
        IQueryResults Execute();
    }

    public class ExecutableQuery : IExecutableQuery
    {
        public IExecutableQuery Query(string query)
        {
            QueryText = query;

            return this;
        }

        public IExecutableQuery WithParameters(object parameters)
        {
            QueryParameters = parameters is IDictionary<string, object> dictionaryParameters
                ? dictionaryParameters
                : ConvertObjectToDictionary(parameters);

            return this;
        }

        private IDictionary<string, object> ConvertObjectToDictionary(object parameters)
        {
            if (parameters == null) return new Dictionary<string, object>();

            return parameters
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public)
                .ToDictionary(k => k.Name, v => v.GetValue(parameters));
        }

        public bool IsExecutable()
        {
            return Database != null
                   && QueryText != null;
        }

        public IQueryResults Execute()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists { get; }

        public string Database { get; set; }

        public IDictionary<string, object> QueryParameters { get; private set; } = new Dictionary<string, object>();
        public string QueryText { get; private set; }
    }
}
