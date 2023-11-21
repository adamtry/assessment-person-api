using AssessmentPersonAPI.V1.Boundary.Response;

namespace AssessmentPersonAPI.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
