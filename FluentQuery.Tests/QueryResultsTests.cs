using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;

namespace FluentQuery.Tests
{
    public class QueryResultsTests
    {
        private QueryResults _queryResults;
        private IEnumerable<IDictionary<string, string>> _results;

        [SetUp]
        public void Setup()
        {
            _results = new Dictionary<string, string>[0];
            _queryResults = new QueryResults(_results);
        }

        [Test]
        public void Queryresults_should_be_a_wrapper_for_an_enumerable()
        {
            _queryResults.GetEnumerator()
                .Should()
                .BeSameAs(_results.GetEnumerator());

            _queryResults.Results
                .Should()
                .BeSameAs(_results);
        }
    }

    [TestFixture]
    public class QueryResultsAsTests
    {
        private IEnumerable<IDictionary<string, string>> _results;
        private QueryResults _queryResults;

        private string _publicStringWithGetAndSet;
        private string _publicStringField;
        private string _publicWriteonlyString;
        private int _publicIntWithGetAndSet;
        private string _publicObjectWithGetAndSet;
        private string _privateStringField;
        private string _privateStringProperty;

        [SetUp]
        public void Setup()
        {

            _publicStringWithGetAndSet = Guid.NewGuid().ToString();
            _publicStringField = Guid.NewGuid().ToString();
            _publicWriteonlyString = Guid.NewGuid().ToString();
            _publicIntWithGetAndSet = DateTime.Now.Millisecond;
            _publicObjectWithGetAndSet = "{\"key\": \"value\", \"alpha\": \"12345\"}";
            _privateStringField = Guid.NewGuid().ToString();
            _privateStringProperty = Guid.NewGuid().ToString();

            _results = new[]
            {
                new Dictionary<string, string>()
                {
                    [nameof(TestObject.PublicStringWithGetAndSet)] = _publicStringWithGetAndSet,
                    [nameof(TestObject.PublicStringField)] = _publicStringField,
                    [nameof(TestObject.PublicWriteonlyString)] = _publicWriteonlyString,
                    [nameof(TestObject.PublicIntWithGetAndSet)] = $"{_publicIntWithGetAndSet}",
                    [nameof(TestObject.PublicObjectWithGetAndSet)] = _publicObjectWithGetAndSet,
                    ["PrivateStringField"] = _privateStringField,
                    ["PrivateStringProperty"] = _privateStringProperty,
                }
            };

            _queryResults = new QueryResults(_results);
        }

        [Test]
        public void Public_properties_should_map_by_name()
        {
            var mapped = _queryResults.ResultsAs<TestObject>()
                .FirstOrDefault();

            mapped.PublicIntWithGetAndSet
                .Should().Be(_publicIntWithGetAndSet);
        }
    }
}
