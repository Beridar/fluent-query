namespace FluentQuery
{
    public static class Configuration
    {
        public static IFluentQueryDefaults Defaults { get; } = new FluentQueryDefaults();

        public static IFluentQueryDefaults DefaultDatabase(string database)
        {
            return Defaults.DefaultDatabase(database);
        }

        public static IFluentQueryDefaults DefaultConnectionString(string connectionString)
        {
            return Defaults.DefaultConnectionString(connectionString);
        }
    }

    public interface IFluentQueryDefaults
    {
        public string Database { get; }
        public string ConnectionString { get; }

        IFluentQueryDefaults DefaultDatabase(string database);
        IFluentQueryDefaults DefaultConnectionString(string connectionString);
    }

    internal class FluentQueryDefaults : IFluentQueryDefaults
    {
        public string Database { get; private set; }
        public string ConnectionString { get; private set; }

        public IFluentQueryDefaults DefaultDatabase(string database)
        {
            Database = database;

            return this;
        }

        public IFluentQueryDefaults DefaultConnectionString(string connectionString)
        {
            ConnectionString = connectionString;

            return this;
        }
    }
}
