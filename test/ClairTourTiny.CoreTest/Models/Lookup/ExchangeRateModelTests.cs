using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.Lookup;

namespace ClairTourTiny.Tests.Models.Lookup
{
    [TestFixture]
    public class ExchangeRateModelTests
    {
        [Test]
        public void Currency_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ExchangeRateModel();
            model.Currency = "USD";
            Assert.AreEqual("USD", model.Currency);
        }

        [Test]
        public void Startdate_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ExchangeRateModel();
            var date = new DateTime(2023, 10, 1);
            model.Startdate = date;
            Assert.AreEqual(date, model.Startdate);
        }

        [Test]
        public void Enddate_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ExchangeRateModel();
            var date = new DateTime(2023, 12, 31);
            model.Enddate = date;
            Assert.AreEqual(date, model.Enddate);
        }

        [Test]
        public void Enddate_ShouldBeNullByDefault()
        {
            var model = new ExchangeRateModel();
            Assert.IsNull(model.Enddate);
        }

        [Test]
        public void Ratetodollars_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ExchangeRateModel();
            model.Ratetodollars = 1.23;
            Assert.AreEqual(1.23, model.Ratetodollars);
        }
    }
}