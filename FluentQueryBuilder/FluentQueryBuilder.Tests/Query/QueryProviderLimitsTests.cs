using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentQueryBuilder.Tests.Query
{
    [TestClass]
    public class QueryProviderLimitsTests : QueryProviderTests
    {
        private readonly string _nl = Environment.NewLine;

        [TestMethod]
        public void ShouldBuildLimitationQuery()
        {
            var query = _queryProvider.Take(25).ToArray();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}LIMIT 25 {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildConditionalLimitationQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == false).Take(25).ToArray();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE (boolean = False) {_nl}LIMIT 25 {_nl}";
            Assert.AreEqual(expectedString, query);
        }
    }
}
