using System;
using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class SubmitApplicationRequest : PostRequest
    {
        public SubmitApplicationRequest(string domain) : base(domain)
        {
        }

        public override string BaseURL
        {
            get { return "/v1/application/submit"; }
        }

        public ResponseApplication Submit(Application app)
        {
            base.BeforeRequest();
            _request.AddBody(app);
            var response = _client.Execute<ResponseApplication>(_request);
            return response.Data;
        }
    }
}
