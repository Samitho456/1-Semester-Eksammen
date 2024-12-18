using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.Models
{
    public class Event
    {
        // Creating propertys
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public EventMembers Members { get; set; }



        // Creating the constructors 
        public Event(string name, DateTime dateStart, DateTime dateEnd, string description)
        {
            Id = nextId++;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            Members = new EventMembers();
        }

        public Event(string name, DateTime dateStart, DateTime dateEnd, string description, int maxMembers)
        {
            Id = nextId++;
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Description = description;
            Members = new EventMembers(maxMembers);
        }


        // overriding ToString to creat our own ToString
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date Start : {DateStart}, Date End : {DateEnd}, Description: {Description}";
        }
    }
}

