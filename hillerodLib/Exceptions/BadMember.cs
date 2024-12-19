using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Exceptions
{
    // General Exception Classes for Members
    public class BadMember : Exception

    {
        // Constructor
        public BadMember(string message) : base(message) { }

        // Two Members are identical
        public class DuplicateMember : BadMember 
        {
            public DuplicateMember(string message) : base(message) { }
        }

        // Id is not valid
        public class FaultyId : BadMember
        {
            public FaultyId(string message) : base(message) { }
        }



    }
}
