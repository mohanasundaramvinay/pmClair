using System;
using System.Text.Json;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using Xunit;
public class PhaseModelTests
{
    [Fact]
    public void TestEntityNoProperty()
    {
        var model = new PhaseModel();
        model.EntityNo = "123";
        Assert.Equal("123", model.EntityNo);
    }
    [Fact]
    public void TestJsonSerialization()
    {
        var model = new PhaseModel
        {
            EntityNo = "123",
            PropType = "TypeA",
            RespEmpNo = "Emp001"
        };
        var json = JsonSerializer.Serialize(model);
        Assert.Contains("\"ProposalType\":\"TypeA\"", json);
        Assert.Contains("\"AccountExecutive\":\"Emp001\"", json);
    }
    [Fact]
    public void TestJsonDeserialization()
    {
        var json = "{\"ProposalType\":\"TypeA\",\"AccountExecutive\":\"Emp001\"}";
        var model = JsonSerializer.Deserialize<PhaseModel>(json);
        Assert.Equal("TypeA", model.PropType);
        Assert.Equal("Emp001", model.RespEmpNo);
    }
    // Additional tests for other properties can be added here following the same pattern.
}