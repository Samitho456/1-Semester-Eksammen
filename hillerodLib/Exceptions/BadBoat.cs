using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Exceptions
{
    //General Exception Classes For Boats
    public class BadBoat : Exception
    {
        // Constructor
        public BadBoat(string message) : base(message) { }

        // Two boats with the same Id
        public class DuplicateBoatId : BadBoat
        {
            public DuplicateBoatId(string message) : base(message) { }
        }
        // Id is not valid
        public class FaultyId : BadBoat
        {
            public FaultyId(string message) : base(message) { }
        }
    }
}
