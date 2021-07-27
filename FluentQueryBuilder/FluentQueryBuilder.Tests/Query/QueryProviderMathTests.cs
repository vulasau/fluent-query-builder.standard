using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentQueryBuilder.Tests.Query
{
    [TestClass]
    public class QueryProviderMathTests: QueryProviderTests
    {
        private readonly string _nl = Environment.NewLine;

        [TestMethod]
        public void ShouldBuildCountQuery()
        {
            var query = _queryProvider.Count();
            var expectedString = $"SELECT count() FROM model {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildConditionalCountQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == false).Count();
            var expectedString = $"SELECT count() FROM model {_nl}WHERE (boolean = False) {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildConditionalLimitedCountQuery()
        {
            var query = _queryProvider.Take(25).Where(x => x.BooleanProperty == false).Count();
            var expectedString = $"SELECT count() FROM model {_nl}WHERE (boolean = False) {_nl}LIMIT 25 {_nl}";
            Assert.AreEqual(expectedString, query);
        }
    }
}