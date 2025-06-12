using NUnit.Framework;
public class ProjectEquipmentSubhireModelTests
{
    private ProjectEquipmentSubhireModel _model;

    [SetUp]
    public void Setup()
    {
        _model = new ProjectEquipmentSubhireModel();
    }

    [Test]
    public void TestDefaultValues()
    {
        Assert.AreEqual(string.Empty, _model.EntityNo);
        Assert.AreEqual(string.Empty, _model.PartNo);
        Assert.AreEqual(string.Empty, _model.PartDescription);
        Assert.AreEqual(0, _model.Quantity);
        Assert.IsNull(_model.VendorNo);
        Assert.IsNull(_model.SiteNo);
        Assert.AreEqual(string.Empty, _model.VendorName);
        Assert.IsNull(_model.PONumber);
        Assert.AreEqual(0m, _model.Rate);
        Assert.AreEqual(string.Empty, _model.RateType);
        Assert.AreEqual(0.0, _model.BillableDays);
        Assert.AreEqual(0m, _model.DeliveryRate);
        Assert.AreEqual(0m, _model.ReturnRate);
        Assert.AreEqual(0m, _model.Total);
        Assert.IsNull(_model.InvoiceNo);
        Assert.IsNull(_model.StatusCode);
        Assert.AreEqual(default(DateOnly), _model.StartDate);
        Assert.AreEqual(default(DateOnly), _model.EndDate);
        Assert.AreEqual(0, _model.LineNo);
        Assert.AreEqual(default(DateOnly), _model.ShopReceiptDate);
        Assert.AreEqual(default(DateOnly), _model.ShopReturnDate);
        Assert.IsNull(_model.TransferInboundEntityno);
        Assert.IsNull(_model.TransferOutboundEntityno);
        Assert.IsFalse(_model.TransferLinkedPhases);
    }

    [Test]
    public void TestPropertyAssignments()
    {
        _model.EntityNo = "E123";
        Assert.AreEqual("E123", _model.EntityNo);

        _model.PartNo = "P456";
        Assert.AreEqual("P456", _model.PartNo);

        _model.PartDescription = "Part Description";
        Assert.AreEqual("Part Description", _model.PartDescription);

        _model.Quantity = 10;
        Assert.AreEqual(10, _model.Quantity);

        _model.VendorNo = "V789";
        Assert.AreEqual("V789", _model.VendorNo);

        _model.SiteNo = "S012";
        Assert.AreEqual("S012", _model.SiteNo);

        _model.VendorName = "Vendor Name";
        Assert.AreEqual("Vendor Name", _model.VendorName);

        _model.PONumber = "PO345";
        Assert.AreEqual("PO345", _model.PONumber);

        _model.Rate = 100.50m;
        Assert.AreEqual(100.50m, _model.Rate);

        _model.RateType = "Hourly";
        Assert.AreEqual("Hourly", _model.RateType);

        _model.BillableDays = 5.5;
        Assert.AreEqual(5.5, _model.BillableDays);

        _model.DeliveryRate = 20.75m;
        Assert.AreEqual(20.75m, _model.DeliveryRate);

        _model.ReturnRate = 15.25m;
        Assert.AreEqual(15.25m, _model.ReturnRate);

        _model.Total = 500.00m;
        Assert.AreEqual(500.00m, _model.Total);

        _model.InvoiceNo = "INV678";
        Assert.AreEqual("INV678", _model.InvoiceNo);

        _model.StatusCode = "Active";
        Assert.AreEqual("Active", _model.StatusCode);

        var startDate = new DateOnly(2023, 10, 1);
        _model.StartDate = startDate;
        Assert.AreEqual(startDate, _model.StartDate);

        var endDate = new DateOnly(2023, 10, 31);
        _model.EndDate = endDate;
        Assert.AreEqual(endDate, _model.EndDate);

        _model.LineNo = 1;
        Assert.AreEqual(1, _model.LineNo);

        var shopReceiptDate = new DateOnly(2023, 10, 5);
        _model.ShopReceiptDate = shopReceiptDate;
        Assert.AreEqual(shopReceiptDate, _model.ShopReceiptDate);

        var shopReturnDate = new DateOnly(2023, 10, 25);
        _model.ShopReturnDate = shopReturnDate;
        Assert.AreEqual(shopReturnDate, _model.ShopReturnDate);

        _model.TransferInboundEntityno = "TIE123";
        Assert.AreEqual("TIE123", _model.TransferInboundEntityno);

        _model.TransferOutboundEntityno = "TOE456";
        Assert.AreEqual("TOE456", _model.TransferOutboundEntityno);

        _model.TransferLinkedPhases = true;
        Assert.IsTrue(_model.TransferLinkedPhases);
    }
}