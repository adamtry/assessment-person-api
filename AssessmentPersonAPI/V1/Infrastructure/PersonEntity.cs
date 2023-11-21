using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb.Converters;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentPersonAPI.V1.Infrastructure
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public string Gender {get; set;}
    }
}
