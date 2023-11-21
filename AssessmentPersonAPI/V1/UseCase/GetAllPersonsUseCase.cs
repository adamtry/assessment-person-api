using System.Collections.Generic;
using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AssessmentPersonAPI.V1.UseCase
{
    public class GetAllPersonsUseCase : IGetAllPersonsUseCase
    {
        private IPersonGateway _gateway;
        public GetAllPersonsUseCase(IPersonGateway gateway)
        {
            _gateway = gateway;
        }
        [LogCall]
        public List<PersonResponseObject> Execute()
        {
            return _gateway.GetAll().ToResponse();
        }
    }
}
