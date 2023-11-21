using System.Collections.Generic;
using AssessmentPersonAPI.V1.Boundary.Response;

namespace AssessmentPersonAPI.V1.UseCase.Interfaces
{
    public interface IGetAllPersonsUseCase
    {
        List<PersonResponseObject> Execute();
    }
}
