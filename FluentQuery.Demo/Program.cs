namespace FluentQuery.Demo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var existingTables = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"
                .AsDatabaseQuery()
                .WithConnectionString("DemoDb")
                .ForDatabase("system")
                .Execute();
        }
    }
}
