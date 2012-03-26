using System;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace Tests.com.careerbuilder.api.Requests
{
    [TestClass]
    public class JobRequestTest
    {
        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedBlankJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub("","DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedNullJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub(null, "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedShortJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub("J12345678910", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedLongJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub("J12345678901234567890123456789", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsException_WhenPassedBadJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub("W3T1SK6PN85V725Z6Q3", "DevKey", "api.careerbuilder.com", "", "");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void Constructor_SetsJobDID()
        {
            try
            {
                JobRequestStub request = new JobRequestStub("J3T1SK6PN85V725Z6Q3", "DevKey", "api.careerbuilder.com", "", "");
                Assert.AreEqual("J3T1SK6PN85V725Z6Q3", request.JobDID);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void Retrieve_PerformsCorrectRequest()
        {
            //Setup
            JobRequestStub request = new JobRequestStub("J3T1SK6PN85V725Z6Q3", "DevKey", "api.careerbuilder.com", "", "");
            
            //Mock crap
            RestResponse<Job> response = new RestResponse<Job>();
            response.Data = new Job() {JobTitle="Jeff's crazy job imporieum"};
                        
            var restReq = new Mock<IRestRequest>();
            restReq.Setup(x => x.AddParameter("DeveloperKey", "DevKey"));
            restReq.Setup(x => x.AddParameter("DID", "J3T1SK6PN85V725Z6Q3"));
            restReq.SetupSet(x => x.RootElement = "Job");

            var restClient = new Mock<IRestClient>();
            restClient.SetupSet(x => x.BaseUrl = "https://api.careerbuilder.com/v1/job");
            restClient.Setup(x => x.Execute<Job>(It.IsAny<IRestRequest>())).Returns(response);

            request.Request = restReq.Object;
            request.Client = restClient.Object;
            
            //Assert
            Job myJob = request.Retrieve();
            Assert.AreSame(response.Data, myJob);
            restReq.VerifyAll();
            restClient.VerifyAll();
        }
    }

    class JobRequestStub : JobRequest
    {
        public string DevKey
        {
            get { return _DevKey; }
        }

        public string Domain
        {
            get { return _Domain; }
        }

        public string JobDID
        {
            get { return _JobDID; }
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

        public JobRequestStub(string jobdid, string key, string domain, string cobrand, string siteid)
            : base (jobdid,key, domain, cobrand, siteid)
        {
        }

    }
}
