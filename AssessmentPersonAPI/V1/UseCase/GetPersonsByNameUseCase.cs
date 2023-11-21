using System.Collections.Generic;
using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AssessmentPersonAPI.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetClaimantByIdUseCase
    public class GetPersonsByNameUseCase : IGetPersonsByNameUseCase
    {
        private IPersonGateway _gateway;
        public GetPersonsByNameUseCase(IPersonGateway gateway)
        {
            _gateway = gateway;
        }
        [LogCall]
        //TODO: rename id to the name of the identifier that will be used for this API, the type may also need to change
        public List<ResponseObject> Execute(string name)
        {
            return _gateway.SearchPersons(name).ToResponse();
        }
    }
}