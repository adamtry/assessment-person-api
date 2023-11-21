using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.UseCase;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.UseCase
{
    public class GetByNameUseCaseTests : LogCallAspectFixture
    {
        private Mock<IPersonGateway> _mockGateway;
        private GetPersonsByNameUseCase _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _mockGateway = new Mock<IPersonGateway>();
            _classUnderTest = new GetPersonsByNameUseCase(_mockGateway.Object);
        }

        //TODO: test to check that the use case retrieves the correct record from the database.
        //Guidance on unit testing and example of mocking can be found here https://github.com/LBHackney-IT/lbh-assessment-person-api/wiki/Writing-Unit-Tests
    }
}
