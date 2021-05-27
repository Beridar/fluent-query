namespace FluentQuery
{
    public interface IExecutableQuery : IQueryBuilder
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
    }
}
