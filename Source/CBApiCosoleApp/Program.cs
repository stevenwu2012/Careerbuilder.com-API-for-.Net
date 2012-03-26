using System;
using System.Collections.Generic;
using com.careerbuilder.api;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.models.service;
using com.careerbuilder.api.framework.requests;

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
            BlankApplication myApp = svc.GetBlankApplication(jobs[0].DID);

            //Make a call to https://api.careerbuilder.com/v1/application/submit in test mode
            myApp.Test = true;
            ResponseApplication tempResponse = svc.SubmitApplication(myApp);
            Console.WriteLine(tempResponse.ApplicationStatus);

            //Make a call to https://api.careerbuilder.com/v1/application/form
            string form = svc.GetApplicationForm(jobs[0].DID);
            Console.WriteLine(form);
        }
    }
}
