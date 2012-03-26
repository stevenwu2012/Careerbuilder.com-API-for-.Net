using com.careerbuilder.api;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.com.careerbuilder.api
{
    [TestClass]
    public class CBApiTest
    {
        [TestMethod]
        public void Constructor_DefaultsToCareerbuilderCom()
        {
            CBApiStub svc = new CBApiStub();
            Assert.IsInstanceOfType(svc.Site, typeof(CareerBuilderCom));
        }

        [TestMethod]
        public void GetCategories_ReturnsCategoriesRequest()
        {
            CBApi svc = new CBApi();
            Assert.IsInstanceOfType(svc.GetCategories(), typeof(ICategoryRequest));
        }

        [TestMethod]
        public void GetEmployeeTypes_ReturnsEmpRequest()
        {
            CBApi svc = new CBApi();
            Assert.IsInstanceOfType(svc.GetEmployeeTypes(), typeof(IEmployeeTypesRequest));
        }

        //[TestMethod]
        //public void JobSearch_ReturnsJobSearchRequest()
        //{
        //    CBApi svc = new CBApi();
        //    Assert.IsInstanceOfType(svc.GetBlankApplication(), typeof(BlankApplication));
        //}

        [TestMethod]
        public void JobSearch_ReturnsJobSearchRequest()
        {
            CBApi svc = new CBApi();
            Assert.IsInstanceOfType(svc.JobSearch(), typeof(IJobSearch));
        }
    }

    public class CBApiStub : CBApi
    {
        public TargetSite Site
        {
            get { return _TargetSite; }
        }

        public CBApiStub() : base()
        {
        }
    }
}
