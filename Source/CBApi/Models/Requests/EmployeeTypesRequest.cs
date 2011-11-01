using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;

namespace com.careerbuilder.api.Models
{
    public class EmployeeTypesRequest : GetRequest, IEmployeeTypesRequest
    {
        protected string _CountryCode = "US";

        public EmployeeTypesRequest(string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {
        }

        public override string BaseURL
        {
            get { return "/v1/employeetypes"; }
        }

        public IEmployeeTypesRequest WhereCountryCode(CountryCode value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public IEmployeeTypesRequest WhereHostSite(HostSite value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public List<EmployeeType> ListAll()
        {
            base.BeforeRequest();
            _request.AddParameter("CountryCode", _CountryCode);
            _request.RootElement = "EmployeeTypes";
            var response = _client.Execute<List<EmployeeType>>(_request);
            return response.Data;
        }
    }
}
