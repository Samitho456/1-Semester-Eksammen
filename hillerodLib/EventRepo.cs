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

        // Adds an Event. Throws an exception if an Event object's id is already in the Repo.  
        public void AddEvent(Event newEvent)
        {
            if(!_events.TryAdd(newEvent.Id, newEvent))
                throw new BadEvent.DuplicateEvent($"Event with ID {newEvent.Id} aklready exists.");

        }

        

        //Deletes an Event from the EventRepo
        //Ensures correct arguments by calling the GetEventById method
        public bool DeleteEvent(int id, out Event deletedEvent)
        {
            GetEventById(id);   
            return _events.Remove(id, out deletedEvent);
        }

        // Ensures correct arguments by calling the GetEventById method
        // Deletes the old Event from the Repo and adds the updated version. This ensures that the dictionary key is always equal to the Event object's ID.
        public bool UpdateEvent(int id, Event updateEvent)
        {
            GetEventById(id);
            Event oldEvent = GetEventById(id);
            AddEvent(updateEvent);

            DeleteEvent(id, out oldEvent);
            return true;

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
        // Throws an exception if the argument is invalid.
        public Event GetEventById(int id)
        {
            if (!_events.ContainsKey(id))
            {
                throw new BadEvent.FaultyId($"Event with ID {id} doesn't exist");
            }
            return _events[id];
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

        // Search through _events's DateTime values and if anything exsist in the dictionary adds them to a list witch is then returned.
        public List<Event> SearchEventsByDate(DateOnly date)
        {
            //creating a list to put our results in
            List<Event> results = new List<Event>();

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
            List<Event> results = new List<Event>();

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
