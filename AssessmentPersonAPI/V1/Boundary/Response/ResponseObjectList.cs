using System.Collections.Generic;

namespace AssessmentPersonAPI.V1.Boundary.Response
{
    //TODO: Rename to represent to object you will be returning eg. ResidentInformationList
    public class ResponseObjectList
    {
        //TODO: Rename field to match the name of the response object
        //TODO: add xml comments containing information that will be included in the auto generated swagger docs (https://github.com/LBHackney-IT/lbh-assessment-person-a-p-i/wiki/Controllers-and-Response-Objects)
        public List<ResponseObject> ResponseObjects { get; set; }
    }
}
