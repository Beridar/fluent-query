namespace FluentQuery
{
    public interface ISelectedDatabase : IQueryBuilder
    {
        bool Exists { get; }
        public string Database { get; }
    }

    public class SelectedDatabase : ISelectedDatabase
    {
        public IExecutableQuery Query(string query)
        {
            throw new System.NotImplementedException();
        }

        public IExecutableQuery WithParameters(object parameters)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists { get; }

        public string Database { get; set; }
    }
}
