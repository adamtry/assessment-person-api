using System.Linq;
using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.Controllers;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Controllers
{
    [TestFixture]
    public class AssessmentPersonApiControllerTests : LogCallAspectFixture
    {
        private AssessmentPersonApiController _classUnderTest;
        private Mock<IGetPersonsByQueryUseCase> _mockGetPersonsByQueryUseCase;
        private Mock<IGetAllPersonsUseCase> _mockGetAllPersonsUseCase;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _mockGetPersonsByQueryUseCase = new Mock<IGetPersonsByQueryUseCase>();
            _mockGetAllPersonsUseCase = new Mock<IGetAllPersonsUseCase>();
            _classUnderTest = new AssessmentPersonApiController(
                _mockGetPersonsByQueryUseCase.Object,
                _mockGetAllPersonsUseCase.Object
            );
            _fixture = new Fixture();

            _classUnderTest.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() };
        }

        [Test]
        public void GetAllReturnsAllCollectedRecords()
        {
            var testPersonResponses = _fixture.CreateMany<PersonResponseObject>().ToList();
            _mockGetAllPersonsUseCase.Setup(uc => uc.Execute()).Returns(testPersonResponses);

            var response = _classUnderTest.GetAll();
            (response as OkObjectResult).StatusCode.Should().Be(200);
            (response as OkObjectResult).Value.Should().BeEquivalentTo(testPersonResponses);
        }

        [Test]
        public void SearchReturnsAllCollectedRecords()
        {
            var testPersonResponses = _fixture.CreateMany<PersonResponseObject>().ToList();
            _mockGetPersonsByQueryUseCase.Setup(uc => uc.Execute(It.IsAny<string>())).Returns(testPersonResponses);

            _classUnderTest.ControllerContext.HttpContext.Request.QueryString = new QueryString("?query=test");

            var response = _classUnderTest.Query();

            (response as OkObjectResult).StatusCode.Should().Be(200);
            (response as OkObjectResult).Value.Should().BeEquivalentTo(testPersonResponses);
        }
    }
}
