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
        public BadMember(string message) : base(message) { }

        public class DuplicateMember : BadMember
        {
            public DuplicateMember(string message) : base(message) { }
        }

        public class FaultyId : BadMember
        {
            public FaultyId(string message) : base(message) { }
        }



    }
}
