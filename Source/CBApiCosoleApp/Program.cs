using System;
using System.Collections.Generic;
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

            //Make a call to https://api.careerbuilder.com/v1/categories
            List<Category> codes = svc.GetCategories()
                                      .WhereCountryCode(CountryCode.US)
                                      .ListAll();
            foreach (Category code in codes)
            {
                Console.WriteLine(code.Code);
            }

            //Make a call to https://api.careerbuilder.com/v1/employeetypes
            List<EmployeeType> emps = svc.GetEmployeeTypes()
                                      .WhereCountryCode(CountryCode.US)
                                      .ListAll();
            foreach (EmployeeType emp in emps)
            {
                Console.WriteLine(emp.Code);
            }

            //Search for Jobs
            var search = svc.JobSearch()
                             .WhereKeywords("Sales")
                             .WhereLocation("Atlanta,GA")
                             .WhereCountryCode(CountryCode.US)
                             .OrderBy(OrderByType.Title)
                             .Ascending()
                             .Search();
            var jobs = search.Results;
            foreach (JobSearchResult item in jobs)
            {
                Console.WriteLine(item.JobTitle);
            }

            //Make a call to https://api.careerbuilder.com/v1/recommendations/forjob
            List<RecommendJobResult> jobRecs = svc.GetRecommendationsForJob(jobs[0].DID);
            foreach (RecommendJobResult item in jobRecs)
            {
                Console.WriteLine(item.Title);
            }
            
            //Make a call to https://api.careerbuilder.com/v1/job
            Job myJob = svc.GetJob(jobs[0].DID);
            Console.WriteLine(myJob.JobTitle);

            //Make a call to https://api.careerbuilder.com/v1/application/blank
            BlankApplication myApp = svc.GetBlankApplication("J3T62Q6CCYHCV0Z4DB6");

            

        }
    }
}
