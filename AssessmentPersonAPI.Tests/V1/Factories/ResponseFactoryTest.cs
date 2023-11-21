using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Infrastructure;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Factories
{
    public class ResponseFactoryTest
    {
        //TODO: add assertions for all the fields being mapped in `ResponseFactory.ToResponse()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var domain = new Person();
            var response = domain.ToResponse();
            //TODO: check here that all of the fields have been mapped correctly. i.e. response.fieldOne.Should().Be("one")
        }
    }
}
