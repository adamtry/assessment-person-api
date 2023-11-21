using AutoFixture;
using AssessmentPersonAPI.Tests.V1.Helper;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Gateways;
using AssessmentPersonAPI.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Gateways
{
    //TODO: Remove this file if Postgres gateway is not being used
    //TODO: Rename Tests to match gateway name
    //For instruction on how to run tests please see the wiki: https://github.com/LBHackney-IT/lbh-assessment-person-api/wiki/Running-the-test-suite.
    [TestFixture]
    public class ExampleGatewayTests : DatabaseTests
    {
        private readonly Fixture _fixture = new Fixture();
        private PersonGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new PersonGateway(DatabaseContext);
        }

        [Test]
        public void GetEntityByIdReturnsNullIfEntityDoesntExist()
        {
            var response = _classUnderTest.GetPersonByName("asdf");

            response.Should().BeNull();
        }
    }
}
