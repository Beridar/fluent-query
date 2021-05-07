namespace FluentQuery
{
    public interface IQueryBuilder
    {
        IExecutableQuery Query(string query);
        IExecutableQuery WithParameters(object parameters);
    }
}