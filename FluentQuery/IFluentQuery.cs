using System;

namespace FluentQuery
{
    public interface IFluentQuery
    {
        ISelectedDatabase ForDatabase(string databaseName);
    }

    public class FluentQuery : IFluentQuery
    {
        private readonly Func<ISelectedDatabase> _selectedDatabase;

        public FluentQuery(Func<ISelectedDatabase> selectedDatabase)
        {
            _selectedDatabase = selectedDatabase;
        }

        public ISelectedDatabase ForDatabase(string databaseName)
        {
            var selectedDatabase = _selectedDatabase();

            selectedDatabase.Database = databaseName;

            return selectedDatabase;
        }
    }
}
