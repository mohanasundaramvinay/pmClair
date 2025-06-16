using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectBidExpenseModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeCorrect()
        {
            var model = new ProjectBidExpenseModel();
            Assert.AreEqual(string.Empty, model.EntityNo);
            Assert.AreEqual(0, model.SeqNo);
            Assert.AreEqual(string.Empty, model.ExpenseCode);
            Assert.AreEqual(string.Empty, model.Type);
            Assert.AreEqual(string.Empty, model.Notes);
            Assert.AreEqual(0.0, model.ItemCost);
            Assert.AreEqual(0, model.Quantity);
            Assert.AreEqual(string.Empty, model.Category);
            Assert.AreEqual(0, model.Cost);
        }

        [Test]
        public void SetAndGetProperties_ShouldWorkCorrectly()
        {
            var model = new ProjectBidExpenseModel();
            model.EntityNo = "E123";
            model.SeqNo = 1;
            model.ExpenseCode = "EXP001";
            model.Type = "TypeA";
            model.Notes = "Some notes";
            model.ItemCost = 100.50;
            model.Quantity = 10;
            model.Category = "CategoryA";
            model.Cost = 1000;

            Assert.AreEqual("E123", model.EntityNo);
            Assert.AreEqual(1, model.SeqNo);
            Assert.AreEqual("EXP001", model.ExpenseCode);
            Assert.AreEqual("TypeA", model.Type);
            Assert.AreEqual("Some notes", model.Notes);
            Assert.AreEqual(100.50, model.ItemCost);
            Assert.AreEqual(10, model.Quantity);
            Assert.AreEqual("CategoryA", model.Category);
            Assert.AreEqual(1000, model.Cost);
        }
    }
}