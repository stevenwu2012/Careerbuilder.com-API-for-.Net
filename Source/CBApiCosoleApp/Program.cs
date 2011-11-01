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
            var svc = new CBApi("Enter Dev Key");

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

            Job myJob = svc.GetJob("J8D4K96C22QLXRC37C1");
            Console.WriteLine(myJob.JobTitle);
        }
    }
}
