using NUnit.Framework;

namespace FluentQuery.Tests
{
    [TestFixture]
    public class ExecutableQueryTests
    {
        private ExecutableQuery _executableQuery;

        [SetUp]
        public void Setup()
        {
            _executableQuery = new ExecutableQuery();
        }
    }
}
