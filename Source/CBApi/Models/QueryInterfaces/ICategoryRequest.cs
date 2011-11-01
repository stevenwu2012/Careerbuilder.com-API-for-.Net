using System.Collections.Generic;
using com.careerbuilder.api.Models;
using com.careerbuilder.api.Models.Service;

namespace com.careerbuilder.api.Models
{
    public interface ICategoryRequest
    {
        ICategoryRequest WhereCountryCode(CountryCode value);
        ICategoryRequest WhereHostSite(HostSite value);
        List<Category> ListAll();
    }
}
