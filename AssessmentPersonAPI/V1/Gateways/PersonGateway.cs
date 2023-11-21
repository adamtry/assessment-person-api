using System.Collections.Generic;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Infrastructure;

namespace AssessmentPersonAPI.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class PersonGateway : IPersonGateway
    {
        private readonly DatabaseContext _databaseContext;

        public PersonGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Person GetPersonByName(string name)
        {
            var result = new PersonEntity()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@hackney.gov.uk",
                Gender = "Male"
            };

            return result?.ToDomain();
        }

        public List<PersonEntity> GetAll()
        {
            return new List<PersonEntity>();
        }
    }
}
