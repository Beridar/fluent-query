namespace FluentQuery
{
    public interface ISelectedDatabase : IQueryBuilder
    {
        bool Exists { get; }
    }
}
