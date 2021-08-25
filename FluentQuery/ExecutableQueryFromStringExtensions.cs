namespace FluentQuery
{
    public static class ExecutableQueryFromStringExtensions
    {
        public static IExecutableQuery AsDatabaseQuery(this string query)
        {
            return new ExecutableQuery().Query(query);
        }
    }
}
