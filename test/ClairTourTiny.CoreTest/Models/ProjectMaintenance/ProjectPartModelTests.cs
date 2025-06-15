using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectPartModelTests
    {
        [Test]
        public void PartNo_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.PartNo);
        }

        [Test]
        public void PartNo_SetValue_ShouldReturnSetValue()
        {
            var model = new ProjectPartModel();
            model.PartNo = "12345";
            Assert.AreEqual("12345", model.PartNo);
        }

        [Test]
        public void PartDesc_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.PartDesc);
        }

        [Test]
        public void PartDesc_SetValue_ShouldReturnSetValue()
        {
            var model = new ProjectPartModel();
            model.PartDesc = "Description";
            Assert.AreEqual("Description", model.PartDesc);
        }

        [Test]
        public void CubicInches_DefaultValue_ShouldBeNull()
        {
            var model = new ProjectPartModel();
            Assert.IsNull(model.CubicInches);
        }

        [Test]
        public void CubicInches_SetValue_ShouldReturnSetValue()
        {
            var model = new ProjectPartModel();
            model.CubicInches = 100.5;
            Assert.AreEqual(100.5, model.CubicInches);
        }

        [Test]
        public void Pounds_DefaultValue_ShouldBeNull()
        {
            var model = new ProjectPartModel();
            Assert.IsNull(model.Pounds);
        }

        [Test]
        public void Pounds_SetValue_ShouldReturnSetValue()
        {
            var model = new ProjectPartModel();
            model.Pounds = 50.0;
            Assert.AreEqual(50.0, model.Pounds);
        }

        [Test]
        public void Category_DefaultValue_ShouldBeEmptyString()
        {
            var model = new ProjectPartModel();
            Assert.AreEqual(string.Empty, model.Category);
        }

        [Test]
        public void Category_SetValue_ShouldReturnSetValue()
        {
            var model = new ProjectPartModel();
            model.Category = "Hardware";
            Assert.AreEqual("Hardware", model.Category);
        }
    }
}