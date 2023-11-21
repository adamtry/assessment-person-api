using AutoFixture;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Infrastructure;

namespace AssessmentPersonAPI.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static PersonEntity CreateDatabaseEntity()
        {
            var entity = new Fixture().Create<PersonEntity>();

            return CreateDatabaseEntityFrom(entity);
        }

        public static PersonEntity CreateDatabaseEntityFrom(PersonEntity personEntity)
        {
            return new PersonEntity
            {
                Id = personEntity.Id,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Email = personEntity.Email,
                Gender = personEntity.Gender
            };
        }
    }
}
