using System.Linq;
using AssessmentPersonAPI.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace AssessmentPersonAPI.Tests.V1.Gateways
{
   [TestFixture]
    public class PersonGatewayTests
    {
        private PersonGateway _classUnderTest;
        private string _testData;
        private int _testDataCount;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new PersonGateway();
            _testData = @"[
                {
                    ""id"": 1,
                    ""first_name"": ""Antony"",
                    ""last_name"": ""Fitt"",
                    ""email"": ""afitt0@a8.net"",
                    ""gender"": ""Male""
                },
                {
                    ""id"": 2,
                    ""first_name"": ""James"",
                    ""last_name"": ""Webb"",
                    ""email"": ""jwebb@a8.net"",
                    ""gender"": ""Male""
                },
                {
                    ""id"": 3,
                    ""first_name"": ""James"",
                    ""last_name"": ""Pfieffer"",
                    ""email"": ""jwebb@a8.net"",
                    ""gender"": ""Male""
                },
                {
                    ""id"": 14,
                    ""first_name"": ""Chalmers"",
                    ""last_name"": ""Longfut"",
                    ""email"": ""clongfujam@wp.com"",
                    ""gender"": ""Male""
                },
                {
                    ""id"": 18,
                    ""first_name"": ""Katey"",
                    ""last_name"": ""Soltan"",
                    ""email"": ""ksoltanh@simplemachines.org"",
                    ""gender"": ""Female""
                },
            ]";
            _testDataCount = _testData.Select((_, i) => _testData.Substring(i))
                .Count(sub => sub.StartsWith("first_name"));

            _classUnderTest.RawPersonData = _testData;
        }

        [Test]
        public void GetPersonByNameReturnsAllMatchingPeople()
        {
            var response = _classUnderTest.Search("James");

            response.Count.Should().Be(2);
            response[0].FirstName.Should().Be("James");
            response[0].LastName.Should().Be("Webb");

            response[1].FirstName.Should().Be("James");
            response[1].LastName.Should().Be("Pfieffer");
        }

        [Test]
        public void GetPersonByPartialNameReturnsAllMatchingPeople()
        {
            var response = _classUnderTest.Search("Jam");

            response.Count.Should().Be(3);
            response[0].FirstName.Should().Be("James");
            response[0].LastName.Should().Be("Webb");

            response[1].FirstName.Should().Be("James");
            response[1].LastName.Should().Be("Pfieffer");

            response[2].FirstName.Should().Be("Chalmers");
            response[2].LastName.Should().Be("Longfut");
        }

        [Test]
        public void GetPersonByFullNameReturnsAllMatchingPeople()
        {
            var response = _classUnderTest.Search("Katey Soltan");

            response.Count.Should().Be(1);
            response[0].FirstName.Should().Be("Katey");
            response[0].LastName.Should().Be("Soltan");
        }

        [Test]
        public void SearchPersonsReturnsNoResultsIfNoneMatch()
        {
            var response = _classUnderTest.Search("Jasmine Duncan");

            response.Count.Should().Be(0);
        }

        [Test]
        public void GetAllShouldReturnAll()
        {
            var response = _classUnderTest.GetAll();
            response.Count.Should().Be(_testDataCount);
        }
    }
}
