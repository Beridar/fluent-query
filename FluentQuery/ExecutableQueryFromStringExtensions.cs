namespace FluentQuery
{
    public static class ExecutableQueryFromStringExtensions
    {
        public static IExecutableQuery AsDatabaseQuery(this string query)
        {
            return new ExecutableQuery()
                .ForDatabase(Configuration.Defaults.Database)
                .WithConnectionString(Configuration.Defaults.ConnectionString)
                .Query(query);
        }
    }
}
