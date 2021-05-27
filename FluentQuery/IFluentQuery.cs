namespace FluentQuery
{
    public interface IFluentQuery
    {
        ISelectedDatabase ForDatabase(string databaseName);
    }

    public class FluentQuery : IFluentQuery
    {
        public string Database { get; private set; }

        public ISelectedDatabase ForDatabase(string databaseName)
        {
            Database = databaseName;

            return new SelectedDatabase
            {
                Database = Database
            };
        }
    }
}
