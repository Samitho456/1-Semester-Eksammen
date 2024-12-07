using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class EventRepo
    {
        private Dictionary<int, Event> _events = new Dictionary<int, Event>();

        public void AddEvent(Event newEvent)
        {
            _events.TryAdd(newEvent.Id, newEvent);
        }

        public bool DeleteEvent(int id, out Event deletedEvent)
        {
            return _events.Remove(id, out deletedEvent);
        }

        public bool UpdateEvent(int id, Event updateEvent)
        {
            if (_events.ContainsKey(id))
            {
                _events[id].Name = updateEvent.Name;
                _events[id].DateAndTime = updateEvent.DateAndTime;
                _events[id].Description = updateEvent.Description;
                return true;
            }
            return false;
        }

        public Event GetEventById(int id)
        {
            if (_events.ContainsKey(id))
            {
                return _events[id];
            }
            return null!;
        }
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            foreach (var e in _events)
            {
                events.Add(e.Value);
            }
            return events;
        }


        // Search skal kunne gøres i gennem Name og DateAndTime måske description skal lige tænkes over
        public List<Event> SearchEvent()
        {
            List<Event> result = new List<Event>();

            foreach (var p in _events.Values)
            {

                //if (p.Ingredient.ToLower().Contains(ingredient.ToLower()))
                //{
                //    result.Add(p);
                //}
            }
            return result;
        }

    }
}
