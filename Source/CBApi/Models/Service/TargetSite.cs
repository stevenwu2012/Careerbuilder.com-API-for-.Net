using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.careerbuilder.api.Models.Service
{
    public abstract class TargetSite
    {
        protected string _Domain;

        public string Domain
        {
            get { return _Domain; }
        }
    }
}
