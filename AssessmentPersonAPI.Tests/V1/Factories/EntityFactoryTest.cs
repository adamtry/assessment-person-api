using AutoFixture;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<PersonEntity>();
            var entity = databaseEntity.ToDomain();

            databaseEntity.Id.Should().Be(entity.Id);
        }

        [Test]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<Person>();
            var databaseEntity = entity.ToDatabase();

            entity.Id.Should().Be(databaseEntity.Id);
        }
    }
}
