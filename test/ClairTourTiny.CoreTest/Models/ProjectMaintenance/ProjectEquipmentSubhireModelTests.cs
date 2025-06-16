using System;
using Xunit;

public class ProjectEquipmentSubhireModelTests
{
    [Fact]
    public void DefaultValues_ShouldBeCorrect()
    {
        var model = new ProjectEquipmentSubhireModel();
        Assert.Equal(string.Empty, model.EntityNo);
        Assert.Equal(string.Empty, model.PartNo);
        Assert.Equal(string.Empty, model.PartDescription);
        Assert.Equal(0, model.Quantity);
        Assert.Null(model.VendorNo);
        Assert.Null(model.SiteNo);
        Assert.Equal(string.Empty, model.VendorName);
        Assert.Null(model.PONumber);
        Assert.Equal(0m, model.Rate);
        Assert.Equal(string.Empty, model.RateType);
        Assert.Equal(0.0, model.BillableDays);
        Assert.Equal(0m, model.DeliveryRate);
        Assert.Equal(0m, model.ReturnRate);
        Assert.Equal(0m, model.Total);
        Assert.Null(model.InvoiceNo);
        Assert.Null(model.StatusCode);
        Assert.Equal(default(DateOnly), model.StartDate);
        Assert.Equal(default(DateOnly), model.EndDate);
        Assert.Equal(0, model.LineNo);
        Assert.Equal(default(DateOnly), model.ShopReceiptDate);
        Assert.Equal(default(DateOnly), model.ShopReturnDate);
        Assert.Null(model.TransferInboundEntityno);
        Assert.Null(model.TransferOutboundEntityno);
        Assert.False(model.TransferLinkedPhases);
    }

    [Fact]
    public void SetValues_ShouldBeCorrect()
    {
        var model = new ProjectEquipmentSubhireModel();
        model.EntityNo = "E123";
        model.PartNo = "P456";
        model.PartDescription = "Part Description";
        model.Quantity = 10;
        model.VendorNo = "V789";
        model.SiteNo = "S012";
        model.VendorName = "Vendor Name";
        model.PONumber = "PO345";
        model.Rate = 100.50m;
        model.RateType = "Hourly";
        model.BillableDays = 5.5;
        model.DeliveryRate = 15.75m;
        model.ReturnRate = 10.25m;
        model.Total = 200.00m;
        model.InvoiceNo = "INV678";
        model.StatusCode = "Active";
        model.StartDate = new DateOnly(2023, 1, 1);
        model.EndDate = new DateOnly(2023, 1, 10);
        model.LineNo = 1;
        model.ShopReceiptDate = new DateOnly(2023, 1, 2);
        model.ShopReturnDate = new DateOnly(2023, 1, 9);
        model.TransferInboundEntityno = "TIE123";
        model.TransferOutboundEntityno = "TOE456";
        model.TransferLinkedPhases = true;

        Assert.Equal("E123", model.EntityNo);
        Assert.Equal("P456", model.PartNo);
        Assert.Equal("Part Description", model.PartDescription);
        Assert.Equal(10, model.Quantity);
        Assert.Equal("V789", model.VendorNo);
        Assert.Equal("S012", model.SiteNo);
        Assert.Equal("Vendor Name", model.VendorName);
        Assert.Equal("PO345", model.PONumber);
        Assert.Equal(100.50m, model.Rate);
        Assert.Equal("Hourly", model.RateType);
        Assert.Equal(5.5, model.BillableDays);
        Assert.Equal(15.75m, model.DeliveryRate);
        Assert.Equal(10.25m, model.ReturnRate);
        Assert.Equal(200.00m, model.Total);
        Assert.Equal("INV678", model.InvoiceNo);
        Assert.Equal("Active", model.StatusCode);
        Assert.Equal(new DateOnly(2023, 1, 1), model.StartDate);
        Assert.Equal(new DateOnly(2023, 1, 10), model.EndDate);
        Assert.Equal(1, model.LineNo);
        Assert.Equal(new DateOnly(2023, 1, 2), model.ShopReceiptDate);
        Assert.Equal(new DateOnly(2023, 1, 9), model.ShopReturnDate);
        Assert.Equal("TIE123", model.TransferInboundEntityno);
        Assert.Equal("TOE456", model.TransferOutboundEntityno);
        Assert.True(model.TransferLinkedPhases);
    }
}