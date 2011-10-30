using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api.Models.Service;
using RestSharp;
using com.careerbuilder.api.Models.Responses;


namespace com.careerbuilder.api.Models.Requests
{
    public class Categories : ICategoryRequest
    {
        protected string _CountryCode = "US";
        protected string _Domain = "";
        protected string _DevKey = "";
        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest();

        public Categories(string key, string domain)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "Please provide a valid developer key");
            }
            else
            {
                _DevKey = key;
            }

            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException("domain", "Please provide a valid domain name");
            }
            else
            {
                _Domain = domain;
            }
            
        }

        public string BaseURL
        {
            get { return "/v1/categories"; }
        }

        protected string GetRequestURL()
        {
            StringBuilder url = new StringBuilder(20);
            url.Append("https://");
            url.Append(_Domain);
            url.Append(this.BaseURL);
            return url.ToString();
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

        public List<Responses.Category> ListAll()
        {
            _request.AddParameter("DeveloperKey", _DevKey);
            _request.AddParameter("CountryCode", _CountryCode);
            _request.RootElement = "Categories";
            _client.BaseUrl = GetRequestURL();
            var response = _client.Execute<List<Category>>(_request);
            return response.Data;
        }
    }
}
