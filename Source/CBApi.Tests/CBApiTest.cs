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
