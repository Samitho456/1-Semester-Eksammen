using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class Event
    {     
        // properties
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public EventMembers Members { get; set; }

        // Constructor without max amount of members
        public Event(string name, DateTime dateStart, DateTime dateEnd, string description)
        {
            Id = _nextId++;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            Members = new EventMembers();
        }        
        
        // Constructor with max amount of members
        public Event(string name, DateTime dateStart, DateTime dateEnd, string description, int maxMembers)
        {
            Id = _nextId++;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            Members = new EventMembers(maxMembers);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date Start : {DateStart}, Date End : {DateEnd}, Description: {Description}";
        }
    }
}

