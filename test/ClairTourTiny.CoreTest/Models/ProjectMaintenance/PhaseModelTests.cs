using System;
using System.Text.Json;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests
{
    public class PhaseModelTests
    {
        [Fact]
        public void TestPhaseModelProperties()
        {
            // Arrange
            var phaseModel = new PhaseModel();
            var guid = Guid.NewGuid();
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);

            // Act
            phaseModel.EntityNo = "123";
            phaseModel.EntityDesc = "Description";
            phaseModel.BillingCompany = "Billing Co";
            phaseModel.PropType = "Proposal";
            phaseModel.RespEmpNo = "RespEmp";
            phaseModel.AcctExecEmpNo = "AcctExec";
            phaseModel.OpsMgr = "OpsMgr";
            phaseModel.SecondaryOpsEmpNo = "SecOps";
            phaseModel.CrewOpsEmpNo = "CrewOps";
            phaseModel.EngrEmpNo = "EngrEmp";
            phaseModel.RFPLEmpNo = "RFPL";
            phaseModel.Agency = "Agency";
            phaseModel.Industry = "Industry";
            phaseModel.StartDate = startDate;
            phaseModel.EndDate = endDate;
            phaseModel.EngActiveCd = "Active";
            phaseModel.Probability = 50;
            phaseModel.FinActiveCd = "FinActive";
            phaseModel.PlActiveCd = "PlActive";
            phaseModel.SfActiveCd = "SfActive";
            phaseModel.TruckingConfirmed = true;
            phaseModel.TruckingVendNo = "TruckingVend";
            phaseModel.ReferralProgramID = 1;
            phaseModel.TaxCode = "Tax";
            phaseModel.PollstarArtistID = 100;
            phaseModel.CRMLeadURL = "http://crmlead";
            phaseModel.CustNo = "CustNo";
            phaseModel.Currency = "USD";
            phaseModel.ExchangeRateDate = DateTime.Now;
            phaseModel.PriceLevelValue = 100.0m;
            phaseModel.MatrixCd = "Matrix";
            phaseModel.SubNo = "SubNo";
            phaseModel.ShipNo = "ShipNo";
            phaseModel.LoadOut = DateTime.Now;
            phaseModel.CrewPrep = DateTime.Now;
            phaseModel.FirstShow = DateTime.Now;
            phaseModel.LastShow = DateTime.Now;
            phaseModel.InternalOrg = "InternalOrg";
            phaseModel.PropDueDate = DateTime.Now;
            phaseModel.BidMarkup = 10.0;
            phaseModel.GUID = guid;
            phaseModel.TaxTypeKey = 2;
            phaseModel.OeOrderNo = "OrderNo";
            phaseModel.LeadTime = 5;
            phaseModel.TotalWeight = 200.0;
            phaseModel.TotalCubicInches = 300.0;
            phaseModel.TotalEquipmentCost = 400.0;

            // Assert
            Assert.Equal("123", phaseModel.EntityNo);
            Assert.Equal("Description", phaseModel.EntityDesc);
            Assert.Equal("Billing Co", phaseModel.BillingCompany);
            Assert.Equal("Proposal", phaseModel.PropType);
            Assert.Equal("RespEmp", phaseModel.RespEmpNo);
            Assert.Equal("AcctExec", phaseModel.AcctExecEmpNo);
            Assert.Equal("OpsMgr", phaseModel.OpsMgr);
            Assert.Equal("SecOps", phaseModel.SecondaryOpsEmpNo);
            Assert.Equal("CrewOps", phaseModel.CrewOpsEmpNo);
            Assert.Equal("EngrEmp", phaseModel.EngrEmpNo);
            Assert.Equal("RFPL", phaseModel.RFPLEmpNo);
            Assert.Equal("Agency", phaseModel.Agency);
            Assert.Equal("Industry", phaseModel.Industry);
            Assert.Equal(startDate, phaseModel.StartDate);
            Assert.Equal(endDate, phaseModel.EndDate);
            Assert.Equal("Active", phaseModel.EngActiveCd);
            Assert.Equal(50, phaseModel.Probability);
            Assert.Equal("FinActive", phaseModel.FinActiveCd);
            Assert.Equal("PlActive", phaseModel.PlActiveCd);
            Assert.Equal("SfActive", phaseModel.SfActiveCd);
            Assert.True(phaseModel.TruckingConfirmed);
            Assert.Equal("TruckingVend", phaseModel.TruckingVendNo);
            Assert.Equal(1, phaseModel.ReferralProgramID);
            Assert.Equal("Tax", phaseModel.TaxCode);
            Assert.Equal(100, phaseModel.PollstarArtistID);
            Assert.Equal("http://crmlead", phaseModel.CRMLeadURL);
            Assert.Equal("CustNo", phaseModel.CustNo);
            Assert.Equal("USD", phaseModel.Currency);
            Assert.NotNull(phaseModel.ExchangeRateDate);
            Assert.Equal(100.0m, phaseModel.PriceLevelValue);
            Assert.Equal("Matrix", phaseModel.MatrixCd);
            Assert.Equal("SubNo", phaseModel.SubNo);
            Assert.Equal("ShipNo", phaseModel.ShipNo);
            Assert.NotNull(phaseModel.LoadOut);
            Assert.NotNull(phaseModel.CrewPrep);
            Assert.NotNull(phaseModel.FirstShow);
            Assert.NotNull(phaseModel.LastShow);
            Assert.Equal("InternalOrg", phaseModel.InternalOrg);
            Assert.NotNull(phaseModel.PropDueDate);
            Assert.Equal(10.0, phaseModel.BidMarkup);
            Assert.Equal(guid, phaseModel.GUID);
            Assert.Equal(2, phaseModel.TaxTypeKey);
            Assert.Equal("OrderNo", phaseModel.OeOrderNo);
            Assert.Equal(5, phaseModel.LeadTime);
            Assert.Equal(200.0, phaseModel.TotalWeight);
            Assert.Equal(300.0, phaseModel.TotalCubicInches);
            Assert.Equal(400.0, phaseModel.TotalEquipmentCost);
        }

        [Fact]
        public void TestPhaseModelJsonSerialization()
        {
            // Arrange
            var phaseModel = new PhaseModel
            {
                EntityNo = "123",
                EntityDesc = "Description",
                BillingCompany = "Billing Co",
                PropType = "Proposal",
                RespEmpNo = "RespEmp",
                AcctExecEmpNo = "AcctExec",
                OpsMgr = "OpsMgr",
                SecondaryOpsEmpNo = "SecOps",
                CrewOpsEmpNo = "CrewOps",
                EngrEmpNo = "EngrEmp",
                RFPLEmpNo = "RFPL",
                Agency = "Agency",
                Industry = "Industry",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                EngActiveCd = "Active",
                Probability = 50,
                FinActiveCd = "FinActive",
                PlActiveCd = "PlActive",
                SfActiveCd = "SfActive",
                TruckingConfirmed = true,
                TruckingVendNo = "TruckingVend",
                ReferralProgramID = 1,
                TaxCode = "Tax",
                PollstarArtistID = 100,
                CRMLeadURL = "http://crmlead",
                CustNo = "CustNo",
                Currency = "USD",
                ExchangeRateDate = DateTime.Now,
                PriceLevelValue = 100.0m,
                MatrixCd = "Matrix",
                SubNo = "SubNo",
                ShipNo = "ShipNo",
                LoadOut = DateTime.Now,
                CrewPrep = DateTime.Now,
                FirstShow = DateTime.Now,
                LastShow = DateTime.Now,
                InternalOrg = "InternalOrg",
                PropDueDate = DateTime.Now,
                BidMarkup = 10.0,
                GUID = Guid.NewGuid(),
                TaxTypeKey = 2,
                OeOrderNo = "OrderNo",
                LeadTime = 5,
                TotalWeight = 200.0,
                TotalCubicInches = 300.0,
                TotalEquipmentCost = 400.0
            };

            // Act
            var json = JsonSerializer.Serialize(phaseModel);
            var deserializedModel = JsonSerializer.Deserialize<PhaseModel>(json);

            // Assert
            Assert.NotNull(deserializedModel);
            Assert.Equal(phaseModel.EntityNo, deserializedModel.EntityNo);
            Assert.Equal(phaseModel.EntityDesc, deserializedModel.EntityDesc);
            Assert.Equal(phaseModel.BillingCompany, deserializedModel.BillingCompany);
            Assert.Equal(phaseModel.PropType, deserializedModel.PropType);
            Assert.Equal(phaseModel.RespEmpNo, deserializedModel.RespEmpNo);
            Assert.Equal(phaseModel.AcctExecEmpNo, deserializedModel.AcctExecEmpNo);
            Assert.Equal(phaseModel.OpsMgr, deserializedModel.OpsMgr);
            Assert.Equal(phaseModel.SecondaryOpsEmpNo, deserializedModel.SecondaryOpsEmpNo);
            Assert.Equal(phaseModel.CrewOpsEmpNo, deserializedModel.CrewOpsEmpNo);
            Assert.Equal(phaseModel.EngrEmpNo, deserializedModel.EngrEmpNo);
            Assert.Equal(phaseModel.RFPLEmpNo, deserializedModel.RFPLEmpNo);
            Assert.Equal(phaseModel.Agency, deserializedModel.Agency);
            Assert.Equal(phaseModel.Industry, deserializedModel.Industry);
            Assert.Equal(phaseModel.StartDate, deserializedModel.StartDate);
            Assert.Equal(phaseModel.EndDate, deserializedModel.EndDate);
            Assert.Equal(phaseModel.EngActiveCd, deserializedModel.EngActiveCd);
            Assert.Equal(phaseModel.Probability, deserializedModel.Probability);
            Assert.Equal(phaseModel.FinActiveCd, deserializedModel.FinActiveCd);
            Assert.Equal(phaseModel.PlActiveCd, deserializedModel.PlActiveCd);
            Assert.Equal(phaseModel.SfActiveCd, deserializedModel.SfActiveCd);
            Assert.Equal(phaseModel.TruckingConfirmed, deserializedModel.TruckingConfirmed);
            Assert.Equal(phaseModel.TruckingVendNo, deserializedModel.TruckingVendNo);
            Assert.Equal(phaseModel.ReferralProgramID, deserializedModel.ReferralProgramID);
            Assert.Equal(phaseModel.TaxCode, deserializedModel.TaxCode);
            Assert.Equal(phaseModel.PollstarArtistID, deserializedModel.PollstarArtistID);
            Assert.Equal(phaseModel.CRMLeadURL, deserializedModel.CRMLeadURL);
            Assert.Equal(phaseModel.CustNo, deserializedModel.CustNo);
            Assert.Equal(phaseModel.Currency, deserializedModel.Currency);
            Assert.Equal(phaseModel.ExchangeRateDate, deserializedModel.ExchangeRateDate);
            Assert.Equal(phaseModel.PriceLevelValue, deserializedModel.PriceLevelValue);
            Assert.Equal(phaseModel.MatrixCd, deserializedModel.MatrixCd);
            Assert.Equal(phaseModel.SubNo, deserializedModel.SubNo);
            Assert.Equal(phaseModel.ShipNo, deserializedModel.ShipNo);
            Assert.Equal(phaseModel.LoadOut, deserializedModel.LoadOut);
            Assert.Equal(phaseModel.CrewPrep, deserializedModel.CrewPrep);
            Assert.Equal(phaseModel.FirstShow, deserializedModel.FirstShow);
            Assert.Equal(phaseModel.LastShow, deserializedModel.LastShow);
            Assert.Equal(phaseModel.InternalOrg, deserializedModel.InternalOrg);
            Assert.Equal(phaseModel.PropDueDate, deserializedModel.PropDueDate);
            Assert.Equal(phaseModel.BidMarkup, deserializedModel.BidMarkup);
            Assert.Equal(phaseModel.GUID, deserializedModel.GUID);
            Assert.Equal(phaseModel.TaxTypeKey, deserializedModel.TaxTypeKey);
            Assert.Equal(phaseModel.OeOrderNo, deserializedModel.OeOrderNo);
            Assert.Equal(phaseModel.LeadTime, deserializedModel.LeadTime);
            Assert.Equal(phaseModel.TotalWeight, deserializedModel.TotalWeight);
            Assert.Equal(phaseModel.TotalCubicInches, deserializedModel.TotalCubicInches);
            Assert.Equal(phaseModel.TotalEquipmentCost, deserializedModel.TotalEquipmentCost);
        }
    }
}