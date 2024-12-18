using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Checks if boat is available
            if(_bookings[newBooking.Id].Boat.IsAvailable) { 
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

    }
}
