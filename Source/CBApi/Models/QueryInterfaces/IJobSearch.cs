using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;
using com.careerbuilder.api.Models.Responses;

namespace com.careerbuilder.api.Models
{
    public interface IJobSearch
    {
        IJobSearch WhereKeywords(string value);
        IJobSearch WhereCompanyName(string value);
        IJobSearch WhereLocation(string value);
        IJobSearch WhereLocation(float latitude, float longitude);
        IJobSearch Radius(int value);
        IJobSearch WhereCountryCode(CountryCode value);
        IJobSearch WhereHostSite(HostSite value);
        IJobSearch WhereSOCCode(string value);
        IJobSearch WherePayGreaterThan(int value);
        IJobSearch WherePayLessThan(int value);
        IJobSearch OrderBy(OrderByType value);
        IJobSearch Ascending();
        IJobSearch Descending();
        IJobSearch SelectTop(int value);
        IJobSearch Limit(int value);
        IJobSearch Offset(int value);
        ResponseJobSearch Search();
    }
}
