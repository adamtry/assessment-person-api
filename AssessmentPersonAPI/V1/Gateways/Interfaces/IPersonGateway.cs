using System.Collections.Generic;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Infrastructure;

namespace AssessmentPersonAPI.V1.Gateways
{
    public interface IPersonGateway
    {
        List<Person> Search(string query);
        List<Person> GetAll();
    }
}
