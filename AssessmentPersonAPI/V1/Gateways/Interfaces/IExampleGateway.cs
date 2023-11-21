using System.Collections.Generic;
using AssessmentPersonAPI.V1.Domain;

namespace AssessmentPersonAPI.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
