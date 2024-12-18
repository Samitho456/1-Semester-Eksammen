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
        public BadBoat(string message) : base(message) { }

        public class DuplicateBoatId : BadBoat
        {
            public DuplicateBoatId(string message) : base(message) { }
        }
        public class FaultyId : BadBoat
        {
            public FaultyId(string message) : base(message) { }
        }
    }
}
