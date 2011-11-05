using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.Models.Responses
{
    public class JobSearchResult
    {
        public string Company { get; set; }
        public string CompanyDetailsURL { get; set; }
        public string DID { get; set; }
        public string Distance { get; set; }
        public string EmploymentType { get; set; }
        public string JobDetailsURL { get; set; }
        public string JobServiceURL { get; set; }
        public float LocationLatitude { get; set; }
        public float LocationLongitude { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public string Pay { get; set; }
        public string SimilarJobsURL { get; set; }
        public string JobTitle { get; set; }
    }
}
