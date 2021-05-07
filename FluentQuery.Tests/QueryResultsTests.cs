using System.Collections.Generic;
using FluentAssertions;
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
}
