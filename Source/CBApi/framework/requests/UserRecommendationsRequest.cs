using System;
using System.Collections.Generic;
using System.Text;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.framework.requests
{
    internal class UserRecommendationsRequest : GetRequest
    {
        protected string _ExternalID = "";

        public UserRecommendationsRequest(string externalID, string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
            if (!string.IsNullOrEmpty(externalID))
            {
                _ExternalID = externalID;
            }
            else
            {
                throw new ArgumentNullException("externalID", "ExternalID is requried");
            }
            
        }

        public override string BaseURL
        {
            get { return "/v1/recommendations/foruser"; }
        }

        public List<RecommendJobResult> GetRecommendations()
        {
            base.BeforeRequest();
            _request.AddParameter("ExternalID", _ExternalID);
            _request.RootElement = "RecommendJobResults";
            var response = _client.Execute<List<RecommendJobResult>>(_request);
            return response.Data;
        }

    }
}
