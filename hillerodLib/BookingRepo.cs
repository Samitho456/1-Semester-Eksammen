﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class BookingRepo
    {
        private Dictionary<int,Booking> _bookings = new Dictionary<int,Booking>();

        // Adds a booking too _bookings Dictionary
        public void AddBooking(Booking newBooking)
        {
            _bookings.TryAdd(newBooking.Id, newBooking);
        }
        // Deletes a Booking
        public bool DeleteBooking(int id, out Booking deletedBooking)
        {
            return _bookings.Remove(id, out deletedBooking);
        }

        //Updates a Booking with a new booking
        public bool UpdateBooking(int id, Booking updateBooking)
        {
            if (_bookings.ContainsKey(id))
            {
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