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
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateAndTime {  get; set; }
        public string Description { get; set; }

        public Event() { }
        public Event(string name, string dateAndTime, string description)
        {
            Id = nextId++;
            Name = name;
            DateAndTime = dateAndTime;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date And Time: {DateAndTime}, Description: {Description}";
        }
    }
}
