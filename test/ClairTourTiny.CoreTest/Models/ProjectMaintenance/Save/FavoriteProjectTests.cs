using System;
using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    public class FavoriteProjectTests
    {
        [Fact]
        public void Username_ShouldNotBeNull_ByDefault()
        {
            var project = new FavoriteProject();
            Assert.NotNull(project.Username);
        }

        [Fact]
        public void Entityno_ShouldNotBeNull_ByDefault()
        {
            var project = new FavoriteProject();
            Assert.NotNull(project.Entityno);
        }

        [Fact]
        public void UpdateTime_ShouldBeSettable()
        {
            var project = new FavoriteProject();
            var now = DateTime.Now;
            project.UpdateTime = now;
            Assert.Equal(now, project.UpdateTime);
        }

        [Fact]
        public void IsInsert_ShouldBeSettable()
        {
            var project = new FavoriteProject();
            project.IsInsert = true;
            Assert.True(project.IsInsert);
            project.IsInsert = false;
            Assert.False(project.IsInsert);
        }

        [Fact]
        public void IsUpdate_ShouldBeSettable()
        {
            var project = new FavoriteProject();
            project.IsUpdate = true;
            Assert.True(project.IsUpdate);
            project.IsUpdate = false;
            Assert.False(project.IsUpdate);
        }

        [Fact]
        public void IsDelete_ShouldBeSettable()
        {
            var project = new FavoriteProject();
            project.IsDelete = true;
            Assert.True(project.IsDelete);
            project.IsDelete = false;
            Assert.False(project.IsDelete);
        }
    }
}