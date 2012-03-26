using System.Collections.Generic;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class EmployeeTypesTest
    {
        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.AreEqual("https://api.careerbuilder.com/v1/employeetypes", request.RequestURL);
        }

        [TestMethod]
        public void WhereCountryCode_ReturnsCategoryRequest()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.IsInstanceOfType(request.WhereCountryCode(CountryCode.SE),typeof(IEmployeeTypesRequest));
        }

        [TestMethod]
        public void WhereCountryCode_SetsCountryCode()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            request.WhereCountryCode(CountryCode.SE);
            Assert.AreEqual("SE", request.CountryCode);
        }

        [TestMethod]
        public void WhereHostSite_ReturnsCategoryRequest()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.IsInstanceOfType(request.WhereHostSite(HostSite.EU), typeof(IEmployeeTypesRequest));
        }

        [TestMethod]
        public void WhereHostSite_SetsCountryCode()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            request.WhereHostSite(HostSite.EU);
            Assert.AreEqual("EU", request.CountryCode);
        }

        [TestMethod]
        public void ListAll_PerformsCorrectRequest()
        {
            //Setup
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            
            //Mock crap
            RestResponse<List<EmployeeType>> response = new RestResponse<List<EmployeeType>>();
            response.Data = new List<EmployeeType>();
                        
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("CountryCode", "NL"));
            restReq.SetupSet(x => x.RootElement = "EmployeeTypes");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/employeetypes");
            restClient.Setup(x => x.Execute<List<EmployeeType>>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;
            
            //Assert
            List<EmployeeType> cats = request.WhereCountryCode(CountryCode.NL).ListAll();
            Assert.IsTrue(cats.Count == 0);
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    class EmployeeTypesStub :  EmployeeTypesRequest
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

        public EmployeeTypesStub(string key, string domain)
            : base(key, domain, "", "")
        {
        }


    }
}
