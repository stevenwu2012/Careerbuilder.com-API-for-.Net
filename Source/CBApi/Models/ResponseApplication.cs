using System;

namespace com.careerbuilder.api.models
{
    public class ResponseApplication
    {
        public DateTime TimeResponseSent { get; set; }
        public float TimeElapsed { get; set; }
        public string ApplicationStatus { get; set; }
    }
}
