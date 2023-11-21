using AssessmentPersonAPI.V1.Boundary.Response;

namespace AssessmentPersonAPI.V1.UseCase.Interfaces
{
    public interface IGetPersonByNameUseCase
    {
        ResponseObject Execute(string name);
    }
}
