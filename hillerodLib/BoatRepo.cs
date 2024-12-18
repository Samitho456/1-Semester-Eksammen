namespace hillerodLib
{
    public class BoatRepo
    {
        // Constructor
        public BoatRepo() { }

        private Dictionary<int, Boat> _boatList = new Dictionary<int, Boat>();

        // Add a boat to dictonary
        public void AddBoat(Boat boat)
        {
            // Throws an exception if the Boat object already exists. 
            if (!_boatList.TryAdd(boat.Id, boat))
                throw new BadBoat.DuplicateBoatId($"Boat with ID {boat.Id} already exists.");
        }

        // Delete a boat by id and out the deleted boat
        public bool DeleteBoat(int boatId, out Boat deleteBoat)
        {
            // Uses the GetBoatById method to ensure correct arguments
            GetBoatById(boatId);
            return _boatList.Remove(boatId, out deleteBoat);
        }

        // Update boat with specific Id with a new boat
        public void UpdateBoat(int id, Boat UpdatedBoat)
        {
            // Uses the GetBoatById method to ensure correct arguments
            Boat oldBoat = GetBoatById(id);
            oldBoat = UpdatedBoat;
            oldBoat.Id = id;
        }

        // Find a boat by id and return the boat with that id
        public Boat GetBoatById(int id)
        {
            // Throws an exception if the Boat doesnt exist
            if (!_boatList.ContainsKey(id))
            {
                throw new BadBoat.FaultyId($"Boat with ID {id} doesn't exist");
            }

            return _boatList[id];
        }

        // Finds boats with matching
        public List<Boat> GetBoatByEnum(BoatType boatEnum)
        {
            List<Boat> result = new List<Boat>(); //list of the matching boat

            // Goes through each boat in the boatRepo and add to result list of enums match
            foreach (Boat boat in _boatList.Values)
            {
                if (boat.Type == boatEnum)
                {
                    result.Add(boat);
                }
            }
            return result;
        }

        // Returns a list of all boats
        public List<Boat> GetAllBoats()
        {
            return _boatList.Values.ToList();
        }

        public List<Boat> FindAvailableBoats()
        {
            List<Boat> result = new List<Boat> ();
            foreach (Boat boat in _boatList.Values)
            {
                if (boat.IsAvailable)
                {
                    result.Add(boat);
                }
            }
            return result;
        }

        public List<Boat> FindAvailableBoatsByDate(BookingRepo bookingRepo, DateOnly date)
        {
            List<Boat> result = new List<Boat>();

            foreach(Booking b in bookingRepo.SearchBoatsNotBookedOn(date))
            {
                if (_boatList.ContainsKey(b.Boat.Id))
                result.Add(b.Boat);
            }
            return result;
        }
    }
}
