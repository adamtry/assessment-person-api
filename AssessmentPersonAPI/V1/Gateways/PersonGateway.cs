using System.Collections.Generic;
using System.Linq;
using AssessmentPersonAPI.V1.Domain;
using AssessmentPersonAPI.V1.Factories;
using AssessmentPersonAPI.V1.Infrastructure;
using Newtonsoft.Json;

namespace AssessmentPersonAPI.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class PersonGateway : IPersonGateway
    {
        public string RawPersonData = @"[
            {
                ""id"": 1,
                ""first_name"": ""Antony"",
                ""last_name"": ""Fitt"",
                ""email"": ""afitt0@a8.net"",
                ""gender"": ""Male""
            },
            {
                ""id"": 2,
                ""first_name"": ""Katey"",
                ""last_name"": ""Gaines"",
                ""email"": ""kgaines1@bbb.org"",
                ""gender"": ""Female""
            },
            {
                ""id"": 3,
                ""first_name"": ""Ardelle"",
                ""last_name"": ""Soames"",
                ""email"": ""asoames2@google.it"",
                ""gender"": ""Female""
            },
            {
                ""id"": 4,
                ""first_name"": ""Kalila"",
                ""last_name"": ""Tennant"",
                ""email"": ""ktennant3@phpbb.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 5,
                ""first_name"": ""Veda"",
                ""last_name"": ""Emma"",
                ""email"": ""vemma4@nature.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 6,
                ""first_name"": ""Pauli"",
                ""last_name"": ""Isacke"",
                ""email"": ""pisacke5@is.gd"",
                ""gender"": ""Female""
            },
            {
                ""id"": 7,
                ""first_name"": ""Belita"",
                ""last_name"": ""Ruoff"",
                ""email"": ""bruoff6@wiley.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 8,
                ""first_name"": ""James"",
                ""last_name"": ""Kubu"",
                ""email"": ""hkubu7@craigslist.org"",
                ""gender"": ""Male""
            },
            {
                ""id"": 9,
                ""first_name"": ""Jasen"",
                ""last_name"": ""Jiroudek"",
                ""email"": ""jjiroudek8@google.it"",
                ""gender"": ""Polygender""
            },
            {
                ""id"": 10,
                ""first_name"": ""Gusty"",
                ""last_name"": ""Tuxill"",
                ""email"": ""gtuxill9@illinois.edu"",
                ""gender"": ""Female""
            },
            {
                ""id"": 11,
                ""first_name"": ""James"",
                ""last_name"": ""Pfeffer"",
                ""email"": ""bpfeffera@amazon.com"",
                ""gender"": ""Male""
            },
            {
                ""id"": 12,
                ""first_name"": ""Mignonne"",
                ""last_name"": ""Whitewood"",
                ""email"": ""mwhitewoodb@godaddy.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 13,
                ""first_name"": ""Moselle"",
                ""last_name"": ""Gaize"",
                ""email"": ""mgaizec@tumblr.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 14,
                ""first_name"": ""Chalmers"",
                ""last_name"": ""Longfut"",
                ""email"": ""clongfujam@wp.com"",
                ""gender"": ""Male""
            },
            {
                ""id"": 15,
                ""first_name"": ""Linnell"",
                ""last_name"": ""Jumont"",
                ""email"": ""ljumonte@storify.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 16,
                ""first_name"": ""Viole"",
                ""last_name"": ""Eaglen"",
                ""email"": ""veaglenf@nytimes.com"",
                ""gender"": ""Female""
            },
            {
                ""id"": 17,
                ""first_name"": ""Sileas"",
                ""last_name"": ""Tarr"",
                ""email"": ""starrg@telegraph.co.uk"",
                ""gender"": ""Female""
            },
            {
                ""id"": 18,
                ""first_name"": ""Katey"",
                ""last_name"": ""Soltan"",
                ""email"": ""ksoltanh@simplemachines.org"",
                ""gender"": ""Female""
            },
            {
                ""id"": 19,
                ""first_name"": ""Gar"",
                ""last_name"": ""Motion"",
                ""email"": ""gmotioni@shop-pro.jp"",
                ""gender"": ""Male""
            },
            {
                ""id"": 20,
                ""first_name"": ""Kameko"",
                ""last_name"": ""Vanes"",
                ""email"": ""kvanesj@discuz.net"",
                ""gender"": ""Female""
            }
        ]";

        public PersonGateway() { }

        public List<Person> Search(string query)
        {
            var allEntities = GetAll();

            var result = allEntities.Where(person =>
            {
                var combinedFields = $"{person.FirstName.ToLower()} {person.LastName.ToLower()} {person.Email.ToLower()}";
                return (combinedFields).Contains(query.ToLower());
            });

            return result.ToList();
        }

        public List<Person> GetAll()
        {
            RawPersonData = RawPersonData.Replace("first_name", "firstName")
                .Replace("last_name", "lastName");
            var data = JsonConvert.DeserializeObject<List<PersonEntity>>(RawPersonData);
            var result = data.Select(x => x.ToDomain()).ToList();
            return result.ToList();
        }
    }
}
