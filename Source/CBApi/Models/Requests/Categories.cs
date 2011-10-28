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
        private string _CountryCode = "US";
        private string _Domain = "";
        private string _DevKey = "";

        public Categories(string key, string domain)
        {
            _DevKey = key;
            _Domain = domain;
        }

        public string BaseURL
        {
            get { return "/v1/categories"; }
        }

        string GetRequestURL(string DevKey)
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
            var client = new RestClient();
            var request = new RestRequest();
            request.AddParameter("DeveloperKey", _DevKey);
            request.AddParameter("CountryCode", _CountryCode);
            request.RootElement = "Categories";
            client.BaseUrl = "https://" + _Domain + this.BaseURL;
            var response = client.Execute<List<Category>>(request);
            return response.Data;
        }
    }
}
