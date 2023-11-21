using AssessmentPersonAPI.V1.Controllers;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Controllers
{
    [TestFixture]
    public class AssessmentPersonApiControllerTests : LogCallAspectFixture
    {
        private AssessmentPersonApiController _classUnderTest;
        private Mock<IGetPersonsByNameUseCase> _mockGetPersonByNameUseCase;

        [SetUp]
        public void SetUp()
        {
            _mockGetPersonByNameUseCase = new Mock<IGetPersonsByNameUseCase>();
            _classUnderTest = new AssessmentPersonApiController(_mockGetPersonByNameUseCase.Object);
        }


        //Add Tests Here
    }
}
