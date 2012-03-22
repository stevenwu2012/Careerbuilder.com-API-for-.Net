using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using com.careerbuilder.api.Models.Responses;
using System;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class UserRecommendationsRequestTest
    {
        [TestMethod]
        public void Constructor_SetsExternalID()
        {
            UserReqStub request = new UserReqStub("ExternalID","DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("ExternalID", request.ExternalID);
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedNullOrEmpty()
        {
            try
            {
                UserReqStub request = new UserReqStub(null, "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }

            try
            {
                UserReqStub request2 = new UserReqStub("", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetRequestURL_BuildsCorrectEndpointAddress()
        {
            UserReqStub request = new UserReqStub("ExternalID", "DevKey", "api.careerbuilder.com", "", "");
            Assert.AreEqual("https://api.careerbuilder.com/v1/recommendations/foruser", request.RequestURL);
        }

        [TestMethod]
        public void GetRecommendations_PerformsCorrectRequest()
        {
            //Setup
            UserReqStub request = new UserReqStub("ExternalID", "DevKey", "api.careerbuilder.com", "", "");

            //Mock crap
            RestResponse<List<RecommendJobResult>> response = new RestResponse<List<RecommendJobResult>>();
            response.Data = new List<RecommendJobResult>();
            
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("ExternalID", "ExternalID"));
            restReq.SetupSet(x => x.RootElement = "RecommendJobResults");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/recommendations/foruser");
            restClient.Setup(x => x.Execute<List<RecommendJobResult>>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;

            //Assert//
            List<RecommendJobResult> resp = request.GetRecommendations();
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    public class UserReqStub : UserRecommendationsRequest
    {
        public string ExternalID
        {
            get { return _ExternalID; }
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

        public UserReqStub(string externalID, string key, string domain, string cobrand, string siteid)
            : base(externalID,key, domain, cobrand, siteid)
        {
        }

    }
}
