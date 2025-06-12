using System;
using Xunit;
public class ProjectRfiModelTests
{
    [Fact]
    public void EntityNo_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.EntityNo);
    }
    [Fact]
    public void InvEntityNo_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.InvEntityNo);
    }
    [Fact]
    public void Description_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.Description = "Test Description";
        Assert.Equal("Test Description", model.Description);
    }
    [Fact]
    public void StartDate_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        var date = DateTime.Now;
        model.StartDate = date;
        Assert.Equal(date, model.StartDate);
    }
    [Fact]
    public void EndDate_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        var date = DateTime.Now;
        model.EndDate = date;
        Assert.Equal(date, model.EndDate);
    }
    [Fact]
    public void Days_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.Days = 10;
        Assert.Equal(10, model.Days);
    }
    [Fact]
    public void Rate_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.Rate = 100.50m;
        Assert.Equal(100.50m, model.Rate);
    }
    [Fact]
    public void RateType_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.RateType);
    }
    [Fact]
    public void Total_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.Total = 1000.00;
        Assert.Equal(1000.00, model.Total);
    }
    [Fact]
    public void Note_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.Note);
    }
    [Fact]
    public void SeqNo_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.SeqNo = 1;
        Assert.Equal(1, model.SeqNo);
    }
    [Fact]
    public void PostInd_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.PostInd);
    }
    [Fact]
    public void AeApproved_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.AeApproved);
    }
    [Fact]
    public void AmApproved_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.AmApproved);
    }
    [Fact]
    public void BillSchedule_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.BillSchedule);
    }
    [Fact]
    public void CreatedBy_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.CreatedBy);
    }
    [Fact]
    public void DateCreated_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        var date = DateTime.Now;
        model.DateCreated = date;
        Assert.Equal(date, model.DateCreated);
    }
    [Fact]
    public void ModifiedBy_DefaultValue_ShouldBeEmptyString()
    {
        var model = new ProjectRfiModel();
        Assert.Equal(string.Empty, model.ModifiedBy);
    }
    [Fact]
    public void DateModified_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        var date = DateTime.Now;
        model.DateModified = date;
        Assert.Equal(date, model.DateModified);
    }
    [Fact]
    public void AccountCode_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.AccountCode = "ACC123";
        Assert.Equal("ACC123", model.AccountCode);
    }
    [Fact]
    public void InvoicedThrough_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        var date = DateTime.Now;
        model.InvoicedThrough = date;
        Assert.Equal(date, model.InvoicedThrough);
    }
    [Fact]
    public void TotalInvoiced_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.TotalInvoiced = 500.00;
        Assert.Equal(500.00, model.TotalInvoiced);
    }
    [Fact]
    public void RevenueCompany_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.RevenueCompany = "RevCo";
        Assert.Equal("RevCo", model.RevenueCompany);
    }
    [Fact]
    public void IsManualAdjustment_CanBeSetAndRetrieved()
    {
        var model = new ProjectRfiModel();
        model.IsManualAdjustment = true;
        Assert.True(model.IsManualAdjustment);
    }
}