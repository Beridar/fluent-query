namespace FluentQuery
{
    public interface IFluentQuery
    {
        ISelectedDatabase ForDatabase(string databaseName);
    }

    public class FluentQuery : IFluentQuery
    {
        public ISelectedDatabase ForDatabase(string databaseName)
        {
            return new SelectedDatabase
            {
                Database = databaseName
            };
        }
    }
}
