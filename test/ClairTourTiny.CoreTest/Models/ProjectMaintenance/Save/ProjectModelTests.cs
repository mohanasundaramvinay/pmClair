using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectModelTests
    {
        [Test]
        public void TestProjectModelPropertyAssignments()
        {
            // Arrange
            var projectModel = new ProjectModel();
            var updateTime = DateTime.Now;
            var entitynoOld = "OldEntity123";
            var entitynoNew = "NewEntity456";
            var entitydesc = "Test Description";
            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 12, 31);
            var custno = "Cust001";
            var subno = "Sub001";
            var shipno = "Ship001";
            var industry = "Tech";
            var bidMarkup = 15.5;
            var probability = 80;
            var currency = "USD";
            var exchangeRateDate = new DateOnly(2023, 10, 1);
            var loadOut = new DateTime(2023, 11, 1);
            var crewPrep = new DateTime(2023, 11, 2);
            var firstShow = new DateTime(2023, 11, 3);
            var lastShow = new DateTime(2023, 11, 4);
            var guid = Guid.NewGuid();
            var priceLevelValue = 100.0;
            var taxTypeKey = "Tax123";
            var oeOrderno = "Order001";
            var leadTime = "2 weeks";
            var matrixcd = "Matrix001";
            var taxCode = "TaxCode001";
            var note = "This is a test note.";
            
            // Act
            projectModel.UpdateTime = updateTime;
            projectModel.EntitynoOld = entitynoOld;
            projectModel.EntitynoNew = entitynoNew;
            projectModel.Entitydesc = entitydesc;
            projectModel.Startdate = startDate;
            projectModel.Enddate = endDate;
            projectModel.Custno = custno;
            projectModel.Subno = subno;
            projectModel.Shipno = shipno;
            projectModel.Industry = industry;
            projectModel.Bidmarkup = bidMarkup;
            projectModel.Probability = probability;
            projectModel.Currency = currency;
            projectModel.ExchangeRateDate = exchangeRateDate;
            projectModel.LoadOut = loadOut;
            projectModel.CrewPrep = crewPrep;
            projectModel.FirstShow = firstShow;
            projectModel.LastShow = lastShow;
            projectModel.Guid = guid;
            projectModel.PriceLevelValue = priceLevelValue;
            projectModel.TaxTypeKey = taxTypeKey;
            projectModel.OeOrderno = oeOrderno;
            projectModel.LeadTime = leadTime;
            projectModel.Matrixcd = matrixcd;
            projectModel.TaxCode = taxCode;
            projectModel.Note = note;
            
            // Assert
            Assert.AreEqual(updateTime, projectModel.UpdateTime);
            Assert.AreEqual(entitynoOld, projectModel.EntitynoOld);
            Assert.AreEqual(entitynoNew, projectModel.EntitynoNew);
            Assert.AreEqual(entitydesc, projectModel.Entitydesc);
            Assert.AreEqual(startDate, projectModel.Startdate);
            Assert.AreEqual(endDate, projectModel.Enddate);
            Assert.AreEqual(custno, projectModel.Custno);
            Assert.AreEqual(subno, projectModel.Subno);
            Assert.AreEqual(shipno, projectModel.Shipno);
            Assert.AreEqual(industry, projectModel.Industry);
            Assert.AreEqual(bidMarkup, projectModel.Bidmarkup);
            Assert.AreEqual(probability, projectModel.Probability);
            Assert.AreEqual(currency, projectModel.Currency);
            Assert.AreEqual(exchangeRateDate, projectModel.ExchangeRateDate);
            Assert.AreEqual(loadOut, projectModel.LoadOut);
            Assert.AreEqual(crewPrep, projectModel.CrewPrep);
            Assert.AreEqual(firstShow, projectModel.FirstShow);
            Assert.AreEqual(lastShow, projectModel.LastShow);
            Assert.AreEqual(guid, projectModel.Guid);
            Assert.AreEqual(priceLevelValue, projectModel.PriceLevelValue);
            Assert.AreEqual(taxTypeKey, projectModel.TaxTypeKey);
            Assert.AreEqual(oeOrderno, projectModel.OeOrderno);
            Assert.AreEqual(leadTime, projectModel.LeadTime);
            Assert.AreEqual(matrixcd, projectModel.Matrixcd);
            Assert.AreEqual(taxCode, projectModel.TaxCode);
            Assert.AreEqual(note, projectModel.Note);
        }
    }
}