using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Infrastructure;

namespace AssessmentPersonAPI.V1.Factories
{
    public static class EntityFactory
    {
        public static Person ToDomain(this PersonEntity personEntity)
        {
            return new Person
            {
                Id = personEntity.Id,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Email = personEntity.Email,
                Gender = personEntity.Gender
            };
        }

        public static PersonEntity ToDatabase(this Person person)
        {
            //TODO: Map the rest of the fields in the database object.

            return new PersonEntity
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Gender = person.Gender
            };
        }
    }
}
