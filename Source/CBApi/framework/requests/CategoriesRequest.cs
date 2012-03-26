using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.framework.requests
{
    internal class CategoriesRequest : GetRequest, ICategoryRequest
    {
        protected string _CountryCode = "US";

        public CategoriesRequest(string key, string domain, string cobrand, string siteid)
            : base (key, domain, cobrand, siteid)
        {
        }

        public override string BaseURL
        {
            get { return "/v1/categories"; }
        }

        public ICategoryRequest WhereCountryCode(CountryCode value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public ICategoryRequest WhereHostSite(HostSite value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public List<Category> ListAll()
        {
            base.BeforeRequest();
            _request.AddParameter("CountryCode", _CountryCode);
            _request.RootElement = "Categories";
            var response = _client.Execute<List<Category>>(_request);
            return response.Data;
        }
    }
}
