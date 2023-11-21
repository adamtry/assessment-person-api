using System.Collections.Generic;
using System.Linq;
using AssessmentPersonAPI.V1.Boundary.Response;
using AssessmentPersonAPI.V1.Domain;

namespace AssessmentPersonAPI.V1.Factories
{
    public static class ResponseFactory
    {
        public static PersonResponseObject ToResponse(this Person domain)
        {
            return new PersonResponseObject()
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Email = domain.Email,
                Gender = domain.Gender
            };
        }

        public static List<PersonResponseObject> ToResponse(this IEnumerable<Person> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
