using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hillerodLib
{
    public class BookingRepo
    {
        private Dictionary<int, Booking> _bookings = new Dictionary<int, Booking>();

        // Constructor
        public BookingRepo() { }

        // Adds a booking too _bookings Dictionary if boat is available
        public bool AddBooking(Booking newBooking)
        {
            //Checks if boat is available
            if (!_bookings.ContainsKey(newBooking.Id))
                {
                    return _bookings.TryAdd(newBooking.Id, newBooking); // adds boat to dictionary
                }
            return false;
        }

        // Deletes a Booking with a given id and output deleted booking
        public bool DeleteBooking(int id, out Booking deletedBooking)
        {
            // True if booking is removed
            return _bookings.Remove(id, out deletedBooking);    
        }

        // Updates a Booking with a new booking and same id
        public bool UpdateBooking(int id, Booking updateBooking)
        {
            if (_bookings.ContainsKey(id))
            {
                updateBooking.Id = id; //sets the id of the new booking to the id of the old booking
                _bookings[id] = updateBooking; //updates the booking
                return true;
            }
            return false;
        }

        // Returns all Bookings made
        public List<Booking> GetAllBookings()
        {
            return _bookings.Values.ToList();
        }

        // Returns a specific Booking if Id exsist
        public Booking GetBookingById(int id)
        {
            if (_bookings.ContainsKey(id))
            {
                return _bookings[id];
            }
            return null!;
        }

        public void UpdateAvailable(DateTime now)
        {
            foreach (Booking b in _bookings.Values)
            {
                if (b.Arrival.CompareTo(now) < 0)
                {                
                    b.Boat.IsAvailable = true;
                }
            }
        }

        public void UpdateAvailable(DateOnly date)
        {
            UpdateAvailable(date.ToDateTime(TimeOnly.MinValue));
        }

        // Search through _events's DateTime values and if anything exsist in the dictionary adds them to a list witch is then returned.
        public List<Booking> SearchBoatsNotBookedOn(DateOnly date)
        {
            UpdateAvailable(date);
            List<Booking> results = new List<Booking>();
            Console.WriteLine("booking length" + _bookings.Values.Count);
            foreach (Booking b in _bookings.Values)
            {
                DateOnly depature = DateOnly.FromDateTime(b.Depature);
                DateOnly arrival = DateOnly.FromDateTime(b.Arrival);

                Console.WriteLine("de:");
                Console.WriteLine(depature.CompareTo(date));
                Console.WriteLine("Ar.");
                Console.WriteLine(arrival.CompareTo(date));
                Console.WriteLine();
                if (depature.CompareTo(date) >= 0 || arrival.CompareTo(date) <= 0)
                {
                    results.Add(b);
                }
            }
            return results;
        }




    }
}
