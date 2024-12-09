using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hillerodLib
{
    public class EventRepo
    {
        private Dictionary<int, Event> _events = new Dictionary<int, Event>();


        // Adds an Event. TryAdd dosent throw an exception if the key already exists in the dictionary. Compared to add that does throw one  
        public void AddEvent(Event newEvent)
        {
            _events.TryAdd(newEvent.Id, newEvent);
        }

        // Deletes an Event. given the id is correct. can be used like so:

        // if (eventRepo.DeleteEvent(1, out Event deletedEvent))
        //{
        //    Console.WriteLine($"Event deleted: ID = {deletedEvent.Id}, Name = {deletedEvent.Name}");
        //}
        //else
        //{
        //    Console.WriteLine("Event not found.");
        //}

public bool DeleteEvent(int id, out Event deletedEvent)
        {
            return _events.Remove(id, out deletedEvent);
        }

        public bool UpdateEvent(int id, Event updateEvent)
        {
            if (_events.ContainsKey(id))
            {
                _events[id].Name = updateEvent.Name;
                _events[id].Date = updateEvent.Date;
                _events[id].Description = updateEvent.Description;
                return true;
            }
            return false;
        }

        // returns all events in a list to be printed out
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            foreach (var e in _events)
            {
                events.Add(e.Value);
            }
            return events;
        }

        //returns an Event if Id exsist
        public Event GetEventById(int id)
        {
            if (_events.ContainsKey(id))
            {
                return _events[id];
            }
            return null!;
        }


        // Search through _events's Values and if it exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventByName(string name)
        {
            List<Event> result = new List<Event>();

            foreach (var e in _events.Values)
            {

                if (e.Name.ToLower().Contains(name.ToLower()))
                {
                    result.Add(e);
                }
            }
            return result;
        }

        // Search through _events's Values and if it exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventByDate(string date)
        {
            List<Event> result = new List<Event>();

            foreach (var e in _events.Values)
            {

                if (e.Date.ToLower().Contains(date.ToLower()))
                {
                    result.Add(e);
                }
            }
            return result;
        }

        // Search through _events's Values and if it exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventByDescription(string description)
        {
            List<Event> result = new List<Event>();

            foreach (var e in _events.Values)
            {

                if (e.Description.ToLower().Contains(description.ToLower()))
                {
                    result.Add(e);
                }
            }
            return result;
        }
    }
}
