using System;
using FluentAssertions;
using NUnit.Framework;

namespace FluentQuery.Tests
{
    [TestFixture]
    public class FluentQueryTests
    {
        private FluentQuery _fluentQuery;

        [SetUp]
        public void Setup()
        {
            _fluentQuery = new FluentQuery();
        }

        [Test]
        public void It_should_save_the_database()
        {
            var database = Guid.NewGuid().ToString();

            var selectedDatabase = _fluentQuery
                .ForDatabase(database);

            selectedDatabase.Database
                .Should()
                .Be(database);
        }
    }
}
