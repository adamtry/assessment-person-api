using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssessmentPersonAPI.V1.Controllers
{
    [ApiController]
    [Route("api/v1/residents")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class AssessmentPersonApiController : BaseController
    {
        private readonly IGetPersonByNameUseCase _getPersonByNameUseCase;
        public AssessmentPersonApiController(IGetPersonByNameUseCase getPersonByNameUseCase)
        {
            _getPersonByNameUseCase = getPersonByNameUseCase;
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No ? found for the specified ID</response>
        [ProducesResponseType(typeof(ResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        [Route("{personName}")]
        public IActionResult ViewRecord(string personName)
        {
            return Ok(_getPersonByNameUseCase.Execute(personName));
        }
    }
}
