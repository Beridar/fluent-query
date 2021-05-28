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
        public void An_executableQuery_is_executable_when_there_is_both_a_database_and_a_query()
        {
            _executableQuery.Database = "database";
            _executableQuery.Query("SELECT * FROM table");

            _executableQuery.IsExecutable()
                .Should().BeTrue();
        }
    }
}
