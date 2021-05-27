namespace FluentQuery
{
    public interface ISelectedDatabase : IQueryBuilder
    {
        bool Exists { get; }
        public string Database { get; set; }
    }
}
