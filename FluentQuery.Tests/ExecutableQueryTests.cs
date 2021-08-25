using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FluentQuery.Tests
{
    [TestFixture]
    public class ExecutableQueryTests
    {
        private ExecutableQuery _executableQuery;
        private ExecutableQuery _fullyPreparedQuery;
        private Dictionary<string, object> _keyValuePairParameters;
        private object _savedObjectParameter;

        [SetUp]
        public void Setup()
        {
            _executableQuery = new ExecutableQuery();

            _keyValuePairParameters = new Dictionary<string, object>
            {
                ["Key"] = "value",
                [Guid.NewGuid().ToString()] = Guid.NewGuid()
            };

            _savedObjectParameter = Guid.NewGuid();

            _fullyPreparedQuery = new ExecutableQuery();
            _fullyPreparedQuery.ForDatabase("any database");
            _fullyPreparedQuery.WithConnectionString("a connection string");
            _fullyPreparedQuery.Query("select * from a table");
        }

        [Test]
        public void It_should_save_the_database()
        {
            var database = Guid.NewGuid().ToString();

            var selectedDatabase = _executableQuery
                .ForDatabase(database);

            selectedDatabase.Database
                .Should()
                .Be(database);
        }

        [Test]
        public void WithParameters_should_save_an_existing_dictionary_directly()
        {
            _executableQuery.WithParameters(_keyValuePairParameters);

            _executableQuery.QueryParameters
                .Should().BeSameAs(_keyValuePairParameters);
        }

        [Test]
        public void WithParameters_should_translate_an_existing_object_to_key_value_sets()
        {
            _executableQuery.WithParameters(new
            {
                Key = "value",
                Parameter = _savedObjectParameter
            });

            _executableQuery.QueryParameters["Parameter"]
                .Should().BeSameAs(_savedObjectParameter);
        }

        [Test]
        public void WithParameters_should_treat_null_as_an_empty_set()
        {
            _executableQuery.WithParameters(null);

            _executableQuery.QueryParameters
                .Keys
                .Should().BeEmpty();
        }

        [Test]
        public void Query_should_just_save_the_query()
        {
            var expectedQuery = "SELECT * FROM table";

            _executableQuery.Query(expectedQuery);

            _executableQuery.QueryText
                .Should().Be(expectedQuery);
        }

        [Test]
        public void An_executableQuery_is_executable_when_there_is_a_database_and_a_query_and_a_connection_string()
        {
            _executableQuery.Database = "database";
            _executableQuery.Query("SELECT * FROM table");
            _executableQuery.WithConnectionString("any connection string");

            _executableQuery.IsExecutable()
                .Should().BeTrue();
        }

        [Test]
        public void Execute_should_throw_InvalidOperationException_when_the_query_is_not_executable()
        {
            try
            {
                _executableQuery.Execute();

                Assert.Fail($"Expected {nameof(InvalidOperationException)} to be thrown, but no exception was thrown.");
            }
            catch (InvalidOperationException)
            {
            }
        }

        [Test]
        public void The_connection_string_should_be_saved()
        {
            var expectedConnectionString = "my-custom-connection-string";

            _executableQuery.WithConnectionString(expectedConnectionString);

            _executableQuery.ConnectionString
                .Should().Be(expectedConnectionString);
        }

        [Test]
        public void Not_having_a_connection_string_renders_the_query_unexecutable()
        {
            _fullyPreparedQuery.WithConnectionString(null);

            _fullyPreparedQuery.IsExecutable()
                .Should().BeFalse();
        }
    }
}
