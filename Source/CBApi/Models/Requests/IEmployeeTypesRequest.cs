using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Responses;

namespace com.careerbuilder.api.Models.Requests
{
    public interface IEmployeeTypesRequest
    {
        IEmployeeTypesRequest WhereCountryCode(CountryCode value);
        IEmployeeTypesRequest WhereHostSite(HostSite value);
        List<EmployeeType> ListAll();
    }
}
