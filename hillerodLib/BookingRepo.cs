using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class BookingRepo
    {
        private Dictionary<int,Booking> _bookings = new Dictionary<int,Booking>();

        // Adds a booking too _bookings Dictionary if boat is available
        public bool AddBooking(Booking newBooking)
        {
            if(_bookings[newBooking.Id].Boat.IsAvailable = true) { 
                return _bookings.TryAdd(newBooking.Id, newBooking);
            }
            return false;
        }
        // Deletes a Booking
        public bool DeleteBooking(int id, out Booking deletedBooking)
        {
                return _bookings.Remove(id, out deletedBooking);         
        }

        //Updates a Booking with a new booking and same id
        public bool UpdateBooking(int id, Booking updateBooking)
        {
            if (_bookings.ContainsKey(id))
            {
                int temp = _bookings[id].Id;
                updateBooking.Id = temp;
                _bookings[id] = updateBooking;
                return true;
            }
            return false;
        }

        //Returns all Bookings made
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            foreach (var b in _bookings)
            {
                bookings.Add(b.Value);
            }
            return bookings;
        }

        //Returns a specific Booking if Id exsist
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
