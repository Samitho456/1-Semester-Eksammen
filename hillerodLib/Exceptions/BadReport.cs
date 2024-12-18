using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Exceptions
{
    // General Exception Classes for Reports
    public class BadReport : Exception

    {
        public BadReport(string message) : base(message) { }


        public class FaultyIdReport : BadReport
        {
            public FaultyIdReport(string message) : base(message) { }
        }

        public class DuplicateReport : BadReport
        {
            public DuplicateReport(string message) : base(message) { }
        }



    }
}
