using System;
using FluentQueryBuilder.Attributes;
using FluentQueryBuilder.Query;
using FluentQueryBuilder.Tests.Models;
using FluentQueryBuilder.Tests.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentQueryBuilder.Tests.Query
{
    [TestClass]
    public class QueryProviderSingleSelectorsTests: QueryProviderTests
    {
        private readonly string _nl = Environment.NewLine;
        [TestMethod]
        public void ShouldBuildFirstOrDefaultQuery()
        {
            var query = _queryProvider.FirstOrDefault();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildFirstOrDefaultConditionalQuery()
        {
            var query = _queryProvider.FirstOrDefault(x => x.DoubleProperty != 55.5);
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE (double != 55.5) {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildFirstOrDefaultMultiConditionalQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == false).FirstOrDefault(x => x.DoubleProperty != 55.5);
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE (boolean = False)  AND (double != 55.5) {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildFirstOrDefaultEnumComparisonPredicateQuery()
        {
            var queryProvider = new QueryProvider<ConvertableModel>();

            var query = queryProvider.FirstOrDefault(x => x.ConvertableProperty != EnumValue.Unknown);
            var expectedString = $"SELECT ConvertableProperty_c FROM ConvertableModel {_nl}WHERE (ConvertableProperty_c != NULL) {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildFirstOrDefaultOrderedQueryWithPredicate()
        {
            var query = _queryProvider.OrderByDescending(x => x.IntegerProperty).FirstOrDefault(x => x.ConditionedProperty == "42");
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE (conditioned = '42') {_nl}ORDER BY integer DESC NULLS LAST {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildFirstOrDefaultOrderedQuery()
        {
            var query = _queryProvider.OrderBy(x => x.IntegerProperty).FirstOrDefault();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}ORDER BY integer ASC NULLS LAST {_nl}LIMIT 1{_nl}";
            Assert.AreEqual(expectedString, query);
        }
    }
}
