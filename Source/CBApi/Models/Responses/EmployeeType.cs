using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.Models.Responses
{
    public class EmployeeType
    {
        public string Code { get; set; }
        public List<Name> Names { get;  set; }
    }
}
