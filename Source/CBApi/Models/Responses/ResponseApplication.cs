using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api.Models.Responses;

namespace com.careerbuilder.api.Models
{
    public class ResponseApplication
    {
        public DateTime TimeResponseSent { get; set; }
        public float TimeElapsed { get; set; }
        public string ApplicationStatus { get; set; }
    }
}
