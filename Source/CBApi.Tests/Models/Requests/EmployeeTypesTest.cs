using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.careerbuilder.api;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Responses;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Requests;
using RestSharp;
using Moq;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class EmployeeTypesTest
    {
        [TestMethod]
        public void Constructor_DefaultsToUSCountryCode()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey","api.careerbuilder.com");
            Assert.AreEqual("US", request.CountryCode);
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDevKey()
        {
            try
            {
                EmployeeTypesStub request = new EmployeeTypesStub("", "api.careerbuilder.com");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDevKey()
        {
            try
            {
                EmployeeTypesStub request = new EmployeeTypesStub(null, "api.careerbuilder.com");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnEmptyDomain()
        {
            try
            {
                EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_OnNullDomain()
        {
            try
            {
                EmployeeTypesStub request = new EmployeeTypesStub("DevKey", null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_SetsDevKey()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.AreEqual("DevKey", request.DevKey);
        }

        [TestMethod]
        public void Constructor_SetsDomain()
        {
            EmployeeTypesStub request = new EmployeeTypesStub("DevKey", "api.careerbuilder.com");
            Assert.AreEqual("api.careerbuilder.com", request.Domain);
        }

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

    public class EmployeeTypesStub :  EmployeeTypes
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

        public  EmployeeTypesStub(string key, string domain) : base(key, domain)
        {

        }

    }
}
