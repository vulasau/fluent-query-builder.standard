﻿using System;
using FluentQueryBuilder.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentQueryBuilder.Tests.Query
{
    [TestClass]
    public class QueryProviderSelectorsTests : QueryProviderTests
    {
        private readonly string _nl = Environment.NewLine;

        [TestMethod]
        public void ShouldBuildGetAllQuery()
        {
            var query = _queryProvider.ToArray();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildGetAllConditionalQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == true || (x.IntegerProperty > 10 && x.DoubleProperty < 20.5)).ToArray();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE ((boolean = True) OR ((integer > 10) AND (double < 20.5))) {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildGetAllMultiConditionalQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == true).Where(x => x.IntegerProperty > 10 && x.DateProperty == new DateTime(2018, 1, 1)).ToArray();
            var expectedString = $"SELECT boolean, conditioned, date, double, integer, object, readonly FROM model {_nl}WHERE (boolean = True)  AND ((integer > 10) AND (date = '1/1/2018 12:00:00 AM')) {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildGetAllWithMemberSelectorQuery()
        {
            var query = _queryProvider.Select(x => x.DateProperty).ToArray();
            var expectedString = $"SELECT date FROM model {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildGetAllWithTypeSelectorQuery()
        {
            var query = _queryProvider.Select<NamedFluentModelBase>().ToArray();
            var expectedString = $"SELECT boolean, date FROM model {_nl}";
            Assert.AreEqual(expectedString, query);
        }

        [TestMethod]
        public void ShouldBuildGetAllConditionalWithTypeSelectorQuery()
        {
            var query = _queryProvider.Where(x => x.BooleanProperty == true || (x.IntegerProperty > 10 && x.DoubleProperty < 20.5)).Select<NamedFluentModelBase>().ToArray();
            var expectedString = $"SELECT boolean, date FROM model {_nl}WHERE ((boolean = True) OR ((integer > 10) AND (double < 20.5))) {_nl}";
            Assert.AreEqual(expectedString, query);
        }
    }
}
