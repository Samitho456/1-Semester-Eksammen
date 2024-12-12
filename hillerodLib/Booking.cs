using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Booking
    {
        public List<Member> Members {  get; set; }
        private static int nextId = 1;
        public int Id {  get; set; }
        public DateTime Depature { get; set; }
        public DateTime Arrival { get; set; }
        public string Destanation { get; set; }

        public Booking(List<Member> members, DateTime depature, DateTime arrival, string destanation)
        {
            Id = nextId++;
            Members = members;
            Depature = depature;
            Arrival = arrival;
            Destanation = destanation;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Depature: {Depature}, Arrival: {Arrival}, Destanation {Destanation}";
        }
    }
}
