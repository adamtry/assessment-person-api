using System.Collections.Generic;
using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AssessmentPersonAPI.V1.UseCase
{
    public class QueryPersonsUseCase : IGetPersonsByQueryUseCase
    {
        private IPersonGateway _gateway;
        public QueryPersonsUseCase(IPersonGateway gateway)
        {
            _gateway = gateway;
        }
        [LogCall]
        public List<PersonResponseObject> Execute(string query)
        {
            return _gateway.Search(query).ToResponse();
        }
    }
}
