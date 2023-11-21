using System;
using AssessmentPersonAPI.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Domain
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void EntitiesHaveAnId()
        {
            var entity = new PersonEntity();
            entity.Id.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void EntitiesHaveACreatedAt()
        {
            var entity = new PersonEntity();
            var testFirstName = "First Last";
            entity.FirstName = testFirstName;

            entity.FirstName.Should().BeEquivalentTo(testFirstName);
        }
    }
}
