namespace AssessmentPersonAPI.V1.Domain
{
    //TODO: rename this class to be the domain object which this API will getting. e.g. Residents or Claimants
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public string Gender {get; set;}
    }
}
