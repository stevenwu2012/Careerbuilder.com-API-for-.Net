using System.Collections.Generic;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api.models
{
    public interface ICategoryRequest
    {
        ICategoryRequest WhereCountryCode(CountryCode value);
        ICategoryRequest WhereHostSite(HostSite value);
        List<Category> ListAll();
    }
}
