using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.Models.Responses
{
    public class Category
    {
        public string Code { get; set; }
        public List<Name> Names { get;  set; }
    }

    public class Name
    {
        public string Language { get; set; }
        public string Value { get; set; }
    }
}
