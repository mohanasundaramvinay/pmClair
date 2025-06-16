using System;
using Xunit;
public class ProjectRfiModelTests
{
    [Fact]
    public void TestDefaultValues()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.EntityNo);
        Assert.Equal(string.Empty, model.InvEntityNo);
        Assert.Null(model.Description);
        Assert.Equal(default(DateTime), model.StartDate);
        Assert.Equal(default(DateTime), model.EndDate);
        Assert.Equal(0, model.Days);
        Assert.Equal(0m, model.Rate);
        Assert.Equal(string.Empty, model.RateType);
        Assert.Equal(0.0, model.Total);
        Assert.Equal(string.Empty, model.Note);
        Assert.Equal(0, model.SeqNo);
        Assert.Equal(string.Empty, model.PostInd);
        Assert.Equal(string.Empty, model.AeApproved);
        Assert.Equal(string.Empty, model.AmApproved);
        Assert.Equal(string.Empty, model.BillSchedule);
        Assert.Equal(string.Empty, model.CreatedBy);
        Assert.Equal(default(DateTime), model.DateCreated);
        Assert.Equal(string.Empty, model.ModifiedBy);
        Assert.Equal(default(DateTime), model.DateModified);
        Assert.Null(model.AccountCode);
        Assert.Null(model.InvoicedThrough);
        Assert.Equal(0.0, model.TotalInvoiced);
        Assert.Null(model.RevenueCompany);
        Assert.False(model.IsManualAdjustment);
    }
    [Fact]
    public void TestSetAndGetProperties()
    {
        var model = new ProjectRfiModel();
        model.EntityNo = "123";
        model.InvEntityNo = "456";
        model.Description = "Test Description";
        model.StartDate = new DateTime(2023, 1, 1);
        model.EndDate = new DateTime(2023, 12, 31);
        model.Days = 365;
        model.Rate = 100.5m;
        model.RateType = "Hourly";
        model.Total = 36500.0;
        model.Note = "Test Note";
        model.SeqNo = 1;
        model.PostInd = "Yes";
        model.AeApproved = "Yes";
        model.AmApproved = "No";
        model.BillSchedule = "Monthly";
        model.CreatedBy = "User1";
        model.DateCreated = new DateTime(2023, 1, 1);
        model.ModifiedBy = "User2";
        model.DateModified = new DateTime(2023, 6, 1);
        model.AccountCode = "AC123";
        model.InvoicedThrough = new DateTime(2023, 6, 30);
        model.TotalInvoiced = 18000.0;
        model.RevenueCompany = "CompanyX";
        model.IsManualAdjustment = true;
        Assert.Equal("123", model.EntityNo);
        Assert.Equal("456", model.InvEntityNo);
        Assert.Equal("Test Description", model.Description);
        Assert.Equal(new DateTime(2023, 1, 1), model.StartDate);
        Assert.Equal(new DateTime(2023, 12, 31), model.EndDate);
        Assert.Equal(365, model.Days);
        Assert.Equal(100.5m, model.Rate);
        Assert.Equal("Hourly", model.RateType);
        Assert.Equal(36500.0, model.Total);
        Assert.Equal("Test Note", model.Note);
        Assert.Equal(1, model.SeqNo);
        Assert.Equal("Yes", model.PostInd);
        Assert.Equal("Yes", model.AeApproved);
        Assert.Equal("No", model.AmApproved);
        Assert.Equal("Monthly", model.BillSchedule);
        Assert.Equal("User1", model.CreatedBy);
        Assert.Equal(new DateTime(2023, 1, 1), model.DateCreated);
        Assert.Equal("User2", model.ModifiedBy);
        Assert.Equal(new DateTime(2023, 6, 1), model.DateModified);
        Assert.Equal("AC123", model.AccountCode);
        Assert.Equal(new DateTime(2023, 6, 30), model.InvoicedThrough);
        Assert.Equal(18000.0, model.TotalInvoiced);
        Assert.Equal("CompanyX", model.RevenueCompany);
        Assert.True(model.IsManualAdjustment);
    }
}