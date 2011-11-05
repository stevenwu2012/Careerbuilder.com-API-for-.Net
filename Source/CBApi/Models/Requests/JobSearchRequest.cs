using System;
using System.Collections.Generic;
using System.Text;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Responses;

namespace com.careerbuilder.api.Models
{
    public enum BooleanOperator
    {
        AND,
        OR
    }

    public enum OrderBy
    {
        Date,
        Pay,
        Title,
        Company,
        Distace,
        Location,
        Relevance
    }

    public enum OrderDirection
    {
        Ascending,
        Descending
    }

    public class JobSearchRequest : GetRequest, IJobSearch
    {
        protected string _Keywords = "";
        protected string _CompanyName = "";
        protected string _Location = "";
        protected int _Radius = 30;
        protected string _CountryCode = "US";
        protected List<string> _CategoryCodes = new List<string>();
        protected string _Soccode = "";
        protected string _EducationCode = "";
        protected bool _SpecificEducation = false;
        protected int _PostedWithin = 30;
        protected List<string> _EmployeeTypes = new List<string>();
        protected int _MinPay = -1;
        protected int _MaxPay = -1;
        protected int _PageNumber = 1;
        protected int _PerPage = 25;
        protected OrderBy _OrderBy = OrderBy.Relevance;
        protected OrderDirection _OrderDirection = OrderDirection.Descending;
        protected BooleanOperator _BooleanOperator = BooleanOperator.AND;
        protected bool ExcludeNationwideJobs = true;

        public JobSearchRequest(string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {

        }

        public override string BaseURL
        {
            get { return "/v1/jobsearch"; }
        }

        public ResponseJobSearch Search()
        {
            base.BeforeRequest();
            AddParametersToRequest();
            _request.RootElement = "ResponseJobSearch";
            var response = _client.Execute<ResponseJobSearch>(_request);
            return response.Data;
        }
        #region setup request
        protected void AddParametersToRequest()
        {
            AddKeywordsToRequest();
            AddCompanyNameToRequest();
            AddLocationToRequest();
            AddRadiusToRequest();
            AddCountryCodeToRequest();
            AddCategoriesToRequest();
            AddSOCCodeToRequest();
            AddEducationToRequest();
            AddPostedWithinToRequest();
            AddEmployeeTypesToRequest();
        }

        private void AddEmployeeTypesToRequest()
        {
            if (_EmployeeTypes.Count > 0)
            {
                string emps = string.Join(",", _EmployeeTypes);
                _request.AddParameter("EmpType", emps);
            }
        }

        private void AddPostedWithinToRequest()
        {
            if (_PostedWithin >= 1 && _PostedWithin <= 30)
            {
                _request.AddParameter("PostedWithin", _PostedWithin.ToString());
            }
        }

        private void AddEducationToRequest()
        {
            if (!string.IsNullOrEmpty(_EducationCode))
            {
                _request.AddParameter("EducationCode", _EducationCode);
                _request.AddParameter("SpecificEducation", _SpecificEducation.ToString());
            }
        }

        private void AddSOCCodeToRequest()
        {
            if (!string.IsNullOrEmpty(_Soccode))
            {
                _request.AddParameter("SOCCode", _Soccode);
            }
        }

        private void AddCategoriesToRequest()
        {
            if (_CategoryCodes.Count > 0 && _CategoryCodes.Count <= 10)
            {
                string cats = string.Join(",", _CategoryCodes);
                _request.AddParameter("Category", cats);
            }
        }

        private void AddCountryCodeToRequest()
        {
            if (!string.IsNullOrEmpty(_CountryCode))
            {
                _request.AddParameter("CountryCode", _CountryCode);
            }
        }

        private void AddRadiusToRequest()
        {
            if (_Radius >= 5 && _Radius <= 150)
            {
                _request.AddParameter("Radius", _Radius.ToString());
            }
        }

        private void AddLocationToRequest()
        {
            if (!string.IsNullOrEmpty(_Location))
            {
                _request.AddParameter("Location", _Location);
            }
        }

        private void AddCompanyNameToRequest()
        {
            if (!string.IsNullOrEmpty(_CompanyName))
            {
                _request.AddParameter("CompanyName", _CompanyName);
            }
        }

        private void AddKeywordsToRequest()
        {
            if (!string.IsNullOrEmpty(_Keywords))
            {
                _request.AddParameter("Keywords", _Keywords);
            }
        }
        #endregion

        #region IJobSearch Methods
        public IJobSearch WhereCountryCode(CountryCode value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public IJobSearch WhereHostSite(HostSite value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public IJobSearch Keywords(string value)
        {
            _Keywords = value;
            return this;
        }

        public IJobSearch CompanyName(string value)
        {
            _CompanyName = value;
            return this;
        }

        public IJobSearch Location(string value)
        {
            _Location = value;
            return this;
        }

        public IJobSearch Location(float latitude, float longitude)
        {
            _Location = latitude.ToString() + "::" + longitude.ToString();
            return this;
        }

        public IJobSearch Radius(int value)
        {
            _Radius = value;
            return this;
        }
        #endregion
    }
}
