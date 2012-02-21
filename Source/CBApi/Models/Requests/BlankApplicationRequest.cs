using System;
using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;

namespace com.careerbuilder.api.Models
{
    public class BlankApplicationRequest : GetRequest
    {
        protected string _JobDID = "";

        public BlankApplicationRequest(string jobDID, string key, string domain, string cobrand, string siteid)
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
            get { return "/v1/application/blank"; }
        }

        public BlankApplication Retrieve()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _JobDID);
            _request.RootElement = "BlankApplication";
            var response = _client.Execute<BlankApplication>(_request);
            return response.Data;
        }
    }
}
