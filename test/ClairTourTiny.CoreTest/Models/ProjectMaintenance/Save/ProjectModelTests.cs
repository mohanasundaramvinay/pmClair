using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class ProjectModelTests
    {
        [Test]
        public void TestProjectModelProperties()
        {
            // Arrange
            var projectModel = new ProjectModel();
            var updateTime = DateTime.Now;
            var entitynoOld = "OldEntity123";
            var entitynoNew = "NewEntity456";
            var entitydesc = "Test Description";
            var startdate = DateTime.Today;
            var enddate = DateTime.Today.AddDays(10);
            var custno = "Cust001";
            var subno = "Sub001";
            var shipno = "Ship001";
            var billingCompany = "Billing Co";
            var agency = "Agency Name";
            var internalOrg = "Internal Org";
            var industry = "Tech";
            var engactivecd = "Active";
            var finactivecd = "Inactive";
            var respempno = "Emp123";
            var propduedate = DateTime.Today.AddDays(5);
            var proptype = "TypeA";
            var plactivecd = "Active";
            var sfactivecd = "Inactive";
            var opsmgr = "Ops Manager";
            var bidmarkup = 15.5;
            var probability = 80;
            var currency = "USD";
            var exchangeRateDate = new DateOnly(2023, 10, 1);
            var loadOut = DateTime.Today.AddDays(1);
            var crewPrep = DateTime.Today.AddDays(2);
            var firstShow = DateTime.Today.AddDays(3);
            var lastShow = DateTime.Today.AddDays(4);
            var engrEmpno = "Engr123";
            var acctExecEmpno = "AcctExec123";
            var payingPerDiem = true;
            var referralProgramId = (byte)1;
            var truckingConfirmed = false;
            var truckingVendNo = "Vend123";
            var rfplempno = "RFP123";
            var pollstarArtistId = 12345;
            var crmleadUrl = "http://crmlead.url";
            var guid = Guid.NewGuid();
            var priceLevelValue = 100.0;
            var taxTypeKey = "TaxKey";
            var oeOrderno = "Order123";
            var leadTime = "2 weeks";
            var matrixcd = "Matrix123";
            var taxCode = "TaxCode";
            var crewOpsEmpno = "CrewOps123";
            var secondaryOpsEmpno = "SecOps123";
            var note = "This is a note.";
            var secondaryCrewOpsEmpno = "SecCrewOps123";

            // Act
            projectModel.UpdateTime = updateTime;
            projectModel.EntitynoOld = entitynoOld;
            projectModel.EntitynoNew = entitynoNew;
            projectModel.Entitydesc = entitydesc;
            projectModel.Startdate = startdate;
            projectModel.Enddate = enddate;
            projectModel.Custno = custno;
            projectModel.Subno = subno;
            projectModel.Shipno = shipno;
            projectModel.BillingCompany = billingCompany;
            projectModel.Agency = agency;
            projectModel.InternalOrg = internalOrg;
            projectModel.Industry = industry;
            projectModel.Engactivecd = engactivecd;
            projectModel.Finactivecd = finactivecd;
            projectModel.Respempno = respempno;
            projectModel.Propduedate = propduedate;
            projectModel.Proptype = proptype;
            projectModel.Plactivecd = plactivecd;
            projectModel.Sfactivecd = sfactivecd;
            projectModel.Opsmgr = opsmgr;
            projectModel.Bidmarkup = bidmarkup;
            projectModel.Probability = probability;
            projectModel.Currency = currency;
            projectModel.ExchangeRateDate = exchangeRateDate;
            projectModel.LoadOut = loadOut;
            projectModel.CrewPrep = crewPrep;
            projectModel.FirstShow = firstShow;
            projectModel.LastShow = lastShow;
            projectModel.EngrEmpno = engrEmpno;
            projectModel.AcctExecEmpno = acctExecEmpno;
            projectModel.PayingPerDiem = payingPerDiem;
            projectModel.ReferralProgramId = referralProgramId;
            projectModel.TruckingConfirmed = truckingConfirmed;
            projectModel.TruckingVendNo = truckingVendNo;
            projectModel.Rfplempno = rfplempno;
            projectModel.PollstarArtistId = pollstarArtistId;
            projectModel.CrmleadUrl = crmleadUrl;
            projectModel.Guid = guid;
            projectModel.PriceLevelValue = priceLevelValue;
            projectModel.TaxTypeKey = taxTypeKey;
            projectModel.OeOrderno = oeOrderno;
            projectModel.LeadTime = leadTime;
            projectModel.Matrixcd = matrixcd;
            projectModel.TaxCode = taxCode;
            projectModel.CrewOpsEmpno = crewOpsEmpno;
            projectModel.SecondaryOpsEmpno = secondaryOpsEmpno;
            projectModel.Note = note;
            projectModel.SecondaryCrewOpsEmpno = secondaryCrewOpsEmpno;

            // Assert
            Assert.AreEqual(updateTime, projectModel.UpdateTime);
            Assert.AreEqual(entitynoOld, projectModel.EntitynoOld);
            Assert.AreEqual(entitynoNew, projectModel.EntitynoNew);
            Assert.AreEqual(entitydesc, projectModel.Entitydesc);
            Assert.AreEqual(startdate, projectModel.Startdate);
            Assert.AreEqual(enddate, projectModel.Enddate);
            Assert.AreEqual(custno, projectModel.Custno);
            Assert.AreEqual(subno, projectModel.Subno);
            Assert.AreEqual(shipno, projectModel.Shipno);
            Assert.AreEqual(billingCompany, projectModel.BillingCompany);
            Assert.AreEqual(agency, projectModel.Agency);
            Assert.AreEqual(internalOrg, projectModel.InternalOrg);
            Assert.AreEqual(industry, projectModel.Industry);
            Assert.AreEqual(engactivecd, projectModel.Engactivecd);
            Assert.AreEqual(finactivecd, projectModel.Finactivecd);
            Assert.AreEqual(respempno, projectModel.Respempno);
            Assert.AreEqual(propduedate, projectModel.Propduedate);
            Assert.AreEqual(proptype, projectModel.Proptype);
            Assert.AreEqual(plactivecd, projectModel.Plactivecd);
            Assert.AreEqual(sfactivecd, projectModel.Sfactivecd);
            Assert.AreEqual(opsmgr, projectModel.Opsmgr);
            Assert.AreEqual(bidmarkup, projectModel.Bidmarkup);
            Assert.AreEqual(probability, projectModel.Probability);
            Assert.AreEqual(currency, projectModel.Currency);
            Assert.AreEqual(exchangeRateDate, projectModel.ExchangeRateDate);
            Assert.AreEqual(loadOut, projectModel.LoadOut);
            Assert.AreEqual(crewPrep, projectModel.CrewPrep);
            Assert.AreEqual(firstShow, projectModel.FirstShow);
            Assert.AreEqual(lastShow, projectModel.LastShow);
            Assert.AreEqual(engrEmpno, projectModel.EngrEmpno);
            Assert.AreEqual(acctExecEmpno, projectModel.AcctExecEmpno);
            Assert.AreEqual(payingPerDiem, projectModel.PayingPerDiem);
            Assert.AreEqual(referralProgramId, projectModel.ReferralProgramId);
            Assert.AreEqual(truckingConfirmed, projectModel.TruckingConfirmed);
            Assert.AreEqual(truckingVendNo, projectModel.TruckingVendNo);
            Assert.AreEqual(rfplempno, projectModel.Rfplempno);
            Assert.AreEqual(pollstarArtistId, projectModel.PollstarArtistId);
            Assert.AreEqual(crmleadUrl, projectModel.CrmleadUrl);
            Assert.AreEqual(guid, projectModel.Guid);
            Assert.AreEqual(priceLevelValue, projectModel.PriceLevelValue);
            Assert.AreEqual(taxTypeKey, projectModel.TaxTypeKey);
            Assert.AreEqual(oeOrderno, projectModel.OeOrderno);
            Assert.AreEqual(leadTime, projectModel.LeadTime);
            Assert.AreEqual(matrixcd, projectModel.Matrixcd);
            Assert.AreEqual(taxCode, projectModel.TaxCode);
            Assert.AreEqual(crewOpsEmpno, projectModel.CrewOpsEmpno);
            Assert.AreEqual(secondaryOpsEmpno, projectModel.SecondaryOpsEmpno);
            Assert.AreEqual(note, projectModel.Note);
            Assert.AreEqual(secondaryCrewOpsEmpno, projectModel.SecondaryCrewOpsEmpno);
        }
    }
}