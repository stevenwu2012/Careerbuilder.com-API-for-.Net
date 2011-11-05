using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Responses;

namespace com.careerbuilder.api.Models
{
    public interface IJobSearch
    {
        IJobSearch Keywords(string value);
        IJobSearch CompanyName(string value);
        IJobSearch Location(string value);
        IJobSearch Location(float latitude, float longitude);
        IJobSearch Radius(int value);
        IJobSearch WhereCountryCode(CountryCode value);
        IJobSearch WhereHostSite(HostSite value);
        ResponseJobSearch Search();
    }
}
