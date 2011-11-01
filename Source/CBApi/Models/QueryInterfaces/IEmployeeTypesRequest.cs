using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;

namespace com.careerbuilder.api.Models
{
    public interface IEmployeeTypesRequest
    {
        IEmployeeTypesRequest WhereCountryCode(CountryCode value);
        IEmployeeTypesRequest WhereHostSite(HostSite value);
        List<EmployeeType> ListAll();
    }
}
