using System;
using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobRequest : GetRequest
    {
        protected string _JobDID = "";

        internal JobRequest(string jobDID, string key, string domain, string cobrand, string siteid)
            : base (key, domain, cobrand, siteid)
        {
            if (string.IsNullOrEmpty(jobDID))
            {
                throw new ArgumentNullException();
            }
            else if (jobDID.Length >= 18 && jobDID.Length <= 20 && jobDID.StartsWith("J",StringComparison.InvariantCultureIgnoreCase))
            {
                _JobDID = jobDID;
            }
            else
            {
                throw new ArgumentException("This does not look like a job did");
            }
        }

        public override string BaseURL
        {
            get { return "/v1/job"; }
        }

        public Job Retrieve()
        {
            base.BeforeRequest();
            _request.AddParameter("DID", _JobDID);
            _request.RootElement = "Job";
            var response = _client.Execute<Job>(_request);
            return response.Data;
        }
    }
}
