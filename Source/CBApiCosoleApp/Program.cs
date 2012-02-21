using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;

namespace CBApiCosoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new CBApi("Enter your dev key");

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

            //Make a call to https://api.careerbuilder.com/v1/job
            Job myJob = svc.GetJob("J3T62Q6CCYHCV0Z4DB6");
            Console.WriteLine(myJob.JobTitle);

            //Make a call to https://api.careerbuilder.com/v1/application/blank
            BlankApplication myApp = svc.GetBlankApplication("J3T62Q6CCYHCV0Z4DB6");

        }
    }
}
