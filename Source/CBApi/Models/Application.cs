using System;
using System.Collections.Generic;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.models
{
    public class Application
    {
        public string DeveloperKey { get; set; }
        public string JobDID { get; set; }
        public bool Test { get; set; }
        public string SiteID { get; set; }
        public string CoBrand { get; set; }
        public List<Question> Questions { get; set; }
        public Resume Resume { get; set; }

        public void AttachResumeFile(string fileName, byte[] resumeFile)
        {
            Resume = new Resume() { FileName = fileName , ResumeData = Convert.ToBase64String(resumeFile)};
        }
    }
}
