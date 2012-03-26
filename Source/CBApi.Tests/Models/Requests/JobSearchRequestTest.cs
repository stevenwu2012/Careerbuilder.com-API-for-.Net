using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.framework.requests;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class JobSearchRequestTest
    {
        [TestMethod]
        public void Constructor_DefaultsToUSCountryCode()
        {
            JobSearchStub request = new JobSearchStub("DevKey","api.careerbuilder.com","","");
            Assert.AreEqual("US", request.CountryCode);
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            Assert.AreEqual("https://api.careerbuilder.com/v1/jobsearch", request.RequestURL);
        }

        [TestMethod]
        public void WhereCountryCode_ReturnsCategoryRequest()
        {
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            Assert.IsInstanceOfType(request.WhereCountryCode(CountryCode.SE),typeof(IJobSearch));
        }

        [TestMethod]
        public void WhereCountryCode_SetsCountryCode()
        {
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            request.WhereCountryCode(CountryCode.SE);
            Assert.AreEqual("SE", request.CountryCode);
        }

        [TestMethod]
        public void WhereHostSite_ReturnsCategoryRequest()
        {
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            Assert.IsInstanceOfType(request.WhereHostSite(HostSite.EU), typeof(IJobSearch));
        }

        [TestMethod]
        public void WhereHostSite_SetsCountryCode()
        {
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            request.WhereHostSite(HostSite.EU);
            Assert.AreEqual("EU", request.CountryCode);
        }

        [TestMethod]
        public void Search_PerformsCorrectRequest()
        {
            //Setup
            JobSearchStub request = new JobSearchStub("DevKey", "api.careerbuilder.com","","");
            
            //Mock crap
            RestResponse<ResponseJobSearch> response = new RestResponse<ResponseJobSearch>();
            response.Data = new ResponseJobSearch();
                        
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("CountryCode", "NL"));
            restReq.SetupSet(x => x.RootElement = "ResponseJobSearch");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/jobsearch");
            restClient.Setup(x => x.Execute<ResponseJobSearch>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;
            
            //Assert
            ResponseJobSearch resp = request.WhereCountryCode(CountryCode.NL).Search();
            restReq.Verify();
            restClient.VerifyAll();
        }
    }

    class JobSearchStub : JobSearchRequest
    {
        public string DevKey
        {
            get { return _DevKey; }
        }

        public string Domain
        {
            get { return _Domain; }
        }

        public string CountryCode
        {
            get { return _CountryCode; }
        }

        public string RequestURL
        {
            get { return base.GetRequestURL(); }
        }

        public IRestClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public IRestRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }

        public JobSearchStub(string key, string domain, string cobrand, string siteid)
            : base (key, domain, cobrand, siteid)
        {
        }

    }
}
