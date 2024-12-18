using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using hillerodLib.Exceptions;
using hillerodLib.Models;

namespace hillerodLib.Services.Repos
{
    public class EventRepo
    {
        private Dictionary<int, Event> _events = new Dictionary<int, Event>();

        // Adds an Event 
        public void AddEvent(Event newEvent)
        {
            // Throws an exception if an Event object's id is already in the Repo
            if (!_events.TryAdd(newEvent.Id, newEvent))
                throw new BadEvent.DuplicateEvent($"Event with ID {newEvent.Id} already exists.");
        }          

        // Deletes a Event from the EventRepo with a given Id
        public bool DeleteEvent(int id, out Event deletedEvent)
        {
            // Ensures correct arguments by calling the GetEventById method
            GetEventById(id);   
            return _events.Remove(id, out deletedEvent);
        }


        // Deletes the old Event from the Repo and adds the updated version. This ensures that the dictionary key is always equal to the Event object's ID.
        public bool UpdateEvent(int id, Event updateEvent)
        {
            if (_events.ContainsKey(id))
            {
                // Ensures correct arguments by calling the GetEventById method
                Event oldEvent = GetEventById(id);
                updateEvent.Id = id;
                oldEvent = updateEvent;
                return true;
            }
            return false;
        }

        // Returns all events in a list to be printed out
        public List<Event> GetAllEvents()
        {
            return _events.Values.ToList();
        }

        // Returns an Event if Id exsist
        public Event GetEventById(int id)
        {
            // Throws an exception if the argument is invalid.
            if (!_events.ContainsKey(id))
            {
                throw new BadEvent.FaultyId($"Event with ID {id} doesn't exist");
            }
            return _events[id];
        }


        // Search through _events's Values and if it exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventByName(string name)
        {
            List<Event> result = new List<Event>(); // create a list results can be added to
            
            // Dhecks every event if name match, add event to list
            foreach (Event e in _events.Values)
            {
                if (e.Name.ToLower().Contains(name.ToLower()))
                {
                    result.Add(e);
                }
            }
            return result;
        }

        // Search through _events's DateTime values and if anything exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventsByDate(DateOnly date)
        {
            List<Event> results = new List<Event>(); //creating a list to put our results in

            // Goes through every event and if event is on searched date, add then to results
            foreach (Event e in _events.Values)
            {
                // Convert the start and end dates of event to DateOnly for comparison.
                // DateOnly represents the date without time information.
                DateOnly dateOnlyStart = DateOnly.FromDateTime(e.DateStart);
                DateOnly dateOnlyEnd = DateOnly.FromDateTime(e.DateEnd);

                // Compares the date of our parameter with our start date and end date.

                // Compares:
                // if Less than zero (-1):
                //          This instance is earlier than value.
                // if Zero (0):
                //          This instance is the same as value.
                // if Greater than zero (1):
                //          This instance is later than value.
                // So when succes:
                // (e.DateStart.CompareTo(date) needs to be -1 or 0 
                // and 
                // e.DateEnd.CompareTo(date) needs to be 1 or 0

                if (dateOnlyStart.CompareTo(date) <= 0 && dateOnlyEnd.CompareTo(date) >= 0)
                {
                    results.Add(e);
                }
            }
            return results;
        }

        // Search through _events's Values and if it exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventByDescription(string description)
        {
            List<Event> results = new List<Event>(); // create list to put results in

            // goes through every event and if description contains searchword add to list
            foreach (var e in _events.Values)
            {
                if (e.Description.ToLower().Contains(description.ToLower()))
                {
                    results.Add(e);
                }
            }
            return results;
        }
    }
}
