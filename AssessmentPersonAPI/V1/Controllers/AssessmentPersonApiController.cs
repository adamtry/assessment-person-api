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
        private readonly IGetPersonsByQueryUseCase _getPersonsByQueryUseCase;
        private readonly IGetAllPersonsUseCase _getAllPersonsUseCase;

        public AssessmentPersonApiController(IGetPersonsByQueryUseCase getPersonsByQueryUseCase, IGetAllPersonsUseCase getAllPersonsUseCase)
        {
            _getPersonsByQueryUseCase = getPersonsByQueryUseCase;
            _getAllPersonsUseCase = getAllPersonsUseCase;
        }

        /// <summary>
        /// Returns a list of persons matching the specified query
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No ? found for the specified ID</response>
        [ProducesResponseType(typeof(PersonResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        [Route("search")]
        public IActionResult Query()
        {
            var query = HttpContext.Request.Query["query"].ToString();
            var result = _getPersonsByQueryUseCase.Execute(query);
            return Ok(result);
        }

        /// <summary>
        /// Returns all people
        /// </summary>
        /// <response code="200">...</response>
        [ProducesResponseType(typeof(PersonResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        [Route("all")]
        public IActionResult GetAll()
        {
            var result = _getAllPersonsUseCase.Execute();
            return Ok(result);
        }
    }
}
