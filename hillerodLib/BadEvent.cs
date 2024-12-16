using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib

{
    // General Exception Classes for Events
    public class BadEvent : Exception

    {
        public BadEvent(string message) : base(message) { }

        public class DuplicateEvent : BadEvent
        {
            public DuplicateEvent(string message) : base(message) { }

        }

        public class FaultyId : BadEvent 
        {
            public FaultyId(string message) : base(message) { }
        }

    }
}

