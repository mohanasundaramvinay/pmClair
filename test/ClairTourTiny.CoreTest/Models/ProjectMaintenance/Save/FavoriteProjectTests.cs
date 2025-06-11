using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class FavoriteProjectTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            var testDate = DateTime.Now;
            favoriteProject.UpdateTime = testDate;
            Assert.AreEqual(testDate, favoriteProject.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            favoriteProject.IsInsert = true;
            Assert.IsTrue(favoriteProject.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            favoriteProject.IsUpdate = true;
            Assert.IsTrue(favoriteProject.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            favoriteProject.IsDelete = true;
            Assert.IsTrue(favoriteProject.IsDelete);
        }

        [Test]
        public void Username_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            var testUsername = "testuser";
            favoriteProject.Username = testUsername;
            Assert.AreEqual(testUsername, favoriteProject.Username);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var favoriteProject = new FavoriteProject();
            var testEntityno = "12345";
            favoriteProject.Entityno = testEntityno;
            Assert.AreEqual(testEntityno, favoriteProject.Entityno);
        }
    }
}