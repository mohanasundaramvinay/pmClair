using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectPartModelTests
    {
        [Test]
        public void PartNo_ShouldInitializeAsEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.PartNo);
        }

        [Test]
        public void PartDesc_ShouldInitializeAsEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.PartDesc);
        }

        [Test]
        public void CubicInches_ShouldInitializeAsNull()
        {
            var model = new ProjectPartModel();
            Assert.IsNull(model.CubicInches);
        }

        [Test]
        public void Pounds_ShouldInitializeAsNull()
        {
            var model = new ProjectPartModel();
            Assert.IsNull(model.Pounds);
        }

        [Test]
        public void Category_ShouldInitializeAsEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.Category);
        }

        [Test]
        public void ShouldSetPartNo()
        {
            var model = new ProjectPartModel();
            model.PartNo = "12345";
            Assert.AreEqual("12345", model.PartNo);
        }

        [Test]
        public void ShouldSetPartDesc()
        {
            var model = new ProjectPartModel();
            model.PartDesc = "Description";
            Assert.AreEqual("Description", model.PartDesc);
        }

        [Test]
        public void ShouldSetCubicInches()
        {
            var model = new ProjectPartModel();
            model.CubicInches = 100.5;
            Assert.AreEqual(100.5, model.CubicInches);
        }

        [Test]
        public void ShouldSetPounds()
        {
            var model = new ProjectPartModel();
            model.Pounds = 50.0;
            Assert.AreEqual(50.0, model.Pounds);
        }

        [Test]
        public void ShouldSetCategory()
        {
            var model = new ProjectPartModel();
            model.Category = "Hardware";
            Assert.AreEqual("Hardware", model.Category);
        }
    }
}