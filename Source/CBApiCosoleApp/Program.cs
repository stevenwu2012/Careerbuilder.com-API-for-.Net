using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Responses;
using com.careerbuilder.api.Models.Service;

namespace CBApiCosoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new CBApi("EnterDevKey");
            List<Category> codes = svc.GetCategories().WhereCountryCode(CountryCode.US).ListAll();

        }
    }
}
