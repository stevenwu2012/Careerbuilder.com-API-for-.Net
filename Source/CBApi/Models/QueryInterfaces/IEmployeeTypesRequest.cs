using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.models
{
    public interface IEmployeeTypesRequest
    {
        IEmployeeTypesRequest WhereCountryCode(CountryCode value);
        IEmployeeTypesRequest WhereHostSite(HostSite value);
        List<EmployeeType> ListAll();
    }
}
