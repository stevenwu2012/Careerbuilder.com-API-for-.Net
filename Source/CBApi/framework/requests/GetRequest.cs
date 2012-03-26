using System;
using System.Text;
using RestSharp;


namespace com.careerbuilder.api.framework.requests
{
    internal abstract class GetRequest
    {
        protected string _Domain = "";
        protected string _DevKey = "";
        protected string _CobrandCode = "";
        protected string _SiteID = "";

        protected IRestClient _client = new RestClient();
        protected IRestRequest _request = new RestRequest();

        public GetRequest(string key, string domain, string cobrand, string siteid)
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

            _CobrandCode = cobrand;
            _SiteID = siteid;
            
        }

        public virtual string BaseURL
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual string GetRequestURL()
        {
            StringBuilder url = new StringBuilder(20);
            url.Append("https://");
            url.Append(_Domain);
            url.Append(this.BaseURL);
            return url.ToString();
        }

        protected virtual void BeforeRequest()
        {
            _request.AddParameter("DeveloperKey", _DevKey);
            
            if (!string.IsNullOrEmpty(_CobrandCode))
            {
                _request.AddParameter("CoBrand", _CobrandCode);
            }
           
            if (!string.IsNullOrEmpty(_SiteID))
            {
                _request.AddParameter("SiteID", _SiteID);
            }

            _client.BaseUrl = GetRequestURL();
        }
    }
}
