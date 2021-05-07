namespace FluentQuery
{
    public interface IExecutableQuery : IQueryBuilder
    {
        bool IsExecutable();
        IQueryResults Execute();
    }
}