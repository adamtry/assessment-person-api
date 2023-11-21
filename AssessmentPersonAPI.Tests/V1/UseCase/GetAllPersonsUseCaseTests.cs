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

public class GetAllPersonsUseCaseTests : LogCallAspectFixture
{
    private Mock<IPersonGateway> _mockGateway;
    private GetAllPersonsUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void SetUp()
    {
        _mockGateway = new Mock<IPersonGateway>();
        _classUnderTest = new GetAllPersonsUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }

    [Test]
    public void GetAllPersonsReturnsCorrectRecords()
    {
        // Arrange
        var testFirst = _fixture.Create<string>();
        var testLast = _fixture.Create<string>();
        var testResponse = _fixture.CreateMany<Person>(5).ToList();
        testResponse[0].FirstName = testFirst;
        testResponse[0].LastName = testLast;
        _mockGateway.Setup(x => x.GetAll()).Returns(testResponse);

        // Act
        var response = _classUnderTest.Execute();

        // Assert
        response[0].Should().BeEquivalentTo(testResponse[0]);
        response.Count.Should().Be(testResponse.Count);
    }
}

