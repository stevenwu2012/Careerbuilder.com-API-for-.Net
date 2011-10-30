using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Responses;
using com.careerbuilder.api.Models.Requests;

namespace com.careerbuilder.api
{
    public class CBApi
    {
        protected TargetSite _TargetSite = null;
        public string DevKey {get;set;}

        public CBApi()
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = Properties.Settings.Default.DevKey;
        }

        public CBApi(string key)
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = key;
        }

        public ICategoryRequest GetCategories()
        {
            return new Categories(DevKey, _TargetSite.Domain);
        }
    }
}
