using System;
using System.Collections.Generic;
using System.Text;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobRecommendationsRequest : GetRequest
    {
        protected string _JobDID = "";

        public JobRecommendationsRequest(string jobDID, string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
            _JobDID = jobDID;
        }

        public override string BaseURL
        {
            get { return "/v1/recommendations/forjob"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            base.BeforeRequest();
            _request.AddParameter("JobDID", _JobDID);
            _request.RootElement = "RecommendJobResults";
            var response = _client.Execute<List<RecommendJobResult>>(_request);
            return response.Data;
        }

    }
}
