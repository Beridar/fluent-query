using System;

namespace FluentQuery
{
    public interface IFluentQuery
    {
    }

    public class FluentQuery : IFluentQuery
    {
        private readonly Func<ISelectedDatabase> _selectedDatabase;

        public FluentQuery(Func<ISelectedDatabase> selectedDatabase)
        {
            _selectedDatabase = selectedDatabase;
        }
    }
}
