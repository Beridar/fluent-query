namespace FluentQuery.Demo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            FluentQuery.Configuration
                .DefaultConnectionString("Data Source=Demo.Db.db")
                .DefaultDatabase("main");

            var existingTables = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
                .AsDatabaseQuery()
                .Execute();
        }
    }
}
