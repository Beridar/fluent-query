using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public IExecutableQuery WithParameters(object parameters)
        {
            if (parameters == null)
            {
                QueryParameters = null;
                return this;
            }

            QueryParameters = parameters is IDictionary<string, object> dictionaryParameters
                ? dictionaryParameters
                : ConvertObjectToDictionary(parameters);

            return this;
        }

        private IDictionary<string, object> ConvertObjectToDictionary(object parameters)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExecutable()
        {
            throw new System.NotImplementedException();
        }

        public IQueryResults Execute()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists { get; }

        public string Database { get; set; }

        public IDictionary<string, object> QueryParameters { get; private set; }
    }
}
