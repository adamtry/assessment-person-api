namespace AssessmentPersonAPI.V1.Boundary.Response
{
    public class PersonResponseObject
    {
        //TODO: add the fields that this API will return here
        //TODO: add xml comments containing information that will be included in the auto generated swagger docs
        //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-assessment-person-api/wiki/Controllers-and-Response-Objects)

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
