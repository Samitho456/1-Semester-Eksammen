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
        public Boat Boat { get; set; }

        public Booking(List<Member> members, DateTime depature, DateTime arrival, string destanation, Boat boat)
        {
            Id = nextId++;
            Members = members;
            Depature = depature;
            Arrival = arrival;
            Destanation = destanation;
            Boat = boat;
            boat.IsAvailable = false;

        }

        public override string ToString()
        {
            string listMember = "";
            foreach (Member m in Members) 
            {
                listMember += m.Name.ToString() + ",";
            }
            return $"Id: {Id}\nMembers: {listMember} Depature: {Depature}, Arrival: {Arrival}, Destanation: {Destanation}, Boat: {Boat.Name}";
        }
    }
}
