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
        private Mock<IGetByIdUseCase> _mockGetByIdUseCase;
        private Mock<IGetAllUseCase> _mockGetByAllUseCase;

        [SetUp]
        public void SetUp()
        {
            _mockGetByIdUseCase = new Mock<IGetByIdUseCase>();
            _mockGetByAllUseCase = new Mock<IGetAllUseCase>();
            _classUnderTest = new AssessmentPersonApiController(_mockGetByAllUseCase.Object, _mockGetByIdUseCase.Object);
        }


        //Add Tests Here
    }
}
