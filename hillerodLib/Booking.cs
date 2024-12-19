using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Booking
    {
        // properties 
        public List<Member> Members {  get; set; }
        private static int _nextId = 1;
        public int Id {  get; set; }
        public DateTime Depature { get; set; }
        public DateTime Arrival { get; set; }
        public string Destanation { get; set; }
        public Boat Boat { get; set; }
        public bool Active { get; set; }

        // Constructor
        public Booking(List<Member> members, DateTime depature, DateTime arrival, string destanation, Boat boat)
        {
            Id = _nextId++;
            Members = members;
            Depature = depature;
            Arrival = arrival;
            Destanation = destanation;
            Boat = boat;
            Active = true;
        }

        public override string ToString()
        {
            string listMember = "";
            // Adds every member in the booking to a string and add the string to the ToString
            foreach (Member m in Members) 
            {
                if (m != null)
                {
                    listMember += m.Name.ToString() + ",";
                }
                
            }
            return $"Id: {Id}\nMembers: {listMember} Depature: {Depature}, Arrival: {Arrival}, Destanation: {Destanation}, Boat: {Boat.Name}";
        }
    }
}
