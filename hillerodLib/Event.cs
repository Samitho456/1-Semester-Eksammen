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
        public string Date {  get; set; }
        public string Description { get; set; }

        public Event() { }
        public Event(string name, string date, string description)
        {
            Id = nextId++;
            Name = name;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date: {Date}, Description: {Description}";
        }
    }
}
