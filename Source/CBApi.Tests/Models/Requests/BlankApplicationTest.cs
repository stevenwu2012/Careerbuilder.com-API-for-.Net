using System;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class BlankApplicationTest
    {
        [TestMethod]
        public void Constructor_SetsJobDID()
        {
            BlankAppStub request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX","DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("JXXXXXXXXXXXXXXXXXX", request.JobDID);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedNullOrEmpty()
        {
            try
            {
                BlankAppStub request = new BlankAppStub(null, "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }

            try
            {
                BlankAppStub request = new BlankAppStub("", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedBadJobDID()
        {
            try
            {
                BlankAppStub request = new BlankAppStub("UXXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }

            try
            {
                BlankAppStub request = new BlankAppStub("JXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            BlankAppStub request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("https://api.careerbuilder.com/v1/application/blank", request.RequestURL);
        }

        [TestMethod]
        public void Retrieve_PerformsCorrectRequest()
        {
            //Setup
            BlankAppStub request = new BlankAppStub("JXXXXXXXXXXXXXXXXXX", "DevKey", "api.careerbuilder.com", "", "");

            //Mock crap
            RestResponse<BlankApplication> response = new RestResponse<BlankApplication>();
            response.Data = new BlankApplication();

            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("JobDID", "JXXXXXXXXXXXXXXXXXX"));
            restReq.SetupSet(x => x.RootElement = "BlankApplication");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/application/blank");
            restClient.Setup(x => x.Execute<BlankApplication>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert
            BlankApplication resp = request.Retrieve();
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    class BlankAppStub : BlankApplicationRequest
    {
        public string JobDID
        {
            get { return _JobDID; }
        }

        public string DevKey
        {
            get { return _DevKey; }
        }

        public string Domain
        {
            get { return _Domain; }
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

        public BlankAppStub(string jobDID, string key, string domain, string cobrand, string siteid)
            : base(jobDID,key, domain, cobrand, siteid)
        {
        }

    }
}
