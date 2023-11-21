using System.Linq;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.UseCase;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.UseCase;

public class QueryPersonsUseCaseTests : LogCallAspectFixture
{
    private Mock<IPersonGateway> _mockGateway;
    private QueryPersonsUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void SetUp()
    {
        _mockGateway = new Mock<IPersonGateway>();
        _classUnderTest = new QueryPersonsUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }

    [Test]
    public void QueryPersonsReturnsCorrectRecords()
    {
        // Arrange
        var testFirst = _fixture.Create<string>();
        var testLast = _fixture.Create<string>();
        var testResponse = _fixture.CreateMany<Person>(5).ToList();
        testResponse[0].FirstName = testFirst;
        testResponse[0].LastName = testLast;
        var filteredResponse = testResponse.Where(x => x.FirstName == testFirst).ToList();
        _mockGateway.Setup(x => x.Search(testResponse[0].FirstName)).Returns(filteredResponse);

        // Act
        var response = _classUnderTest.Execute(testResponse[0].FirstName);

        // Assert
        response[0].Should().BeEquivalentTo(testResponse[0]);
        response.Count.Should().Be(1);
    }
}

