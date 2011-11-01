using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.Models
{
    public class Money
    {
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string FormattedAmount { get; set; }
    }
}
