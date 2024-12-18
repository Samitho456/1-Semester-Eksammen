using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    // General Exception Classes for Reports
    public class BadReport : Exception

    {
        // Constructor
        public BadReport(string message) : base(message) { }

        // Two Reports have the same Id
        public class DuplicateReport : BadReport
        {
            public DuplicateReport(string message) : base(message) { }
        }


        // Id is not valid
        public class FaultyIdReport : BadReport
        {
            public FaultyIdReport(string message) : base(message) { }
        }



    }
}
