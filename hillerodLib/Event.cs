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
        // Creating propertys
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date {  get; set; }
        public string Description { get; set; }


        // Creating the constructors 
        public Event() { }
        public Event(string name, string date, string description)
        {
            Id = nextId++;
            Name = name;
            Date = date;
            Description = description;
        }

        // overriding ToString to creat our own ToString
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Date: {Date}, Description: {Description}";
        }
    }
}
