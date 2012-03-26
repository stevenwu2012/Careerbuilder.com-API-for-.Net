using System;
using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class ApplicationFormRequest : GetRequest
    {
        protected string _JobDID = "";

        public ApplicationFormRequest(string jobDID, string key, string domain)
            : base (key, domain, "", "")
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
            get { return "/v1/application/form"; }
        }

        public string Retrieve()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _JobDID);
            var response = _client.Execute(_request);
            return response.Content;
        }
    }
}
