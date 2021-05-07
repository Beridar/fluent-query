namespace FluentQuery
{
    public interface IFluentQuery
    {
        ISelectedDatabase ForDatabase(string databaseName);
    }
}