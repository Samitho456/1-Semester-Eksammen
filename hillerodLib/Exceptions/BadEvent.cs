using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Exceptions

{
    // General Exception Classes for Events
    public class BadEvent : Exception

    {
        // Constructor
        public BadEvent(string message) : base(message) { }

        // Two Events have the same Id
        public class DuplicateEvent : BadEvent
        {
            public DuplicateEvent(string message) : base(message) { }
        }

        // Id is not valid
        public class FaultyId : BadEvent 
        {
            public FaultyId(string message) : base(message) { }
        }

    }
}

