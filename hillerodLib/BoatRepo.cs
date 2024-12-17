namespace hillerodLib
{
    public class BoatRepo
    {
        private Dictionary<int, Boat> _boatList = new Dictionary<int, Boat>();

        // Throws an exception if the Boat object already exists. 
        // Add a boat to dictonary
        public void AddBoat(Boat boat)
        {
            if (!_boatList.TryAdd(boat.Id, boat))
                throw new BadBoat.DuplicateBoatId($"Boat with ID {boat.Id} already exists.");
        }


        // Uses the GetBoatById method to ensure correct arguments
        // Delete a boat by id and out the deleted boat
        public bool DeleteBoat(int boatId, out Boat deleteBoat)
        {

            GetBoatById(boatId);
            return _boatList.Remove(boatId, out deleteBoat);
        }

        // Update boat with specific Id with a new boat
        // Uses the GetBoatById method to ensure correct arguments
        // Deletes the old boat from the dictionary and adds the updated version. This ensures that the dictionary key is always equal to the Boat objects ID.
        public void UpdateBoat(int id, Boat boat)
        {
            GetBoatById(id);
            Boat oldBoat = GetBoatById(id);
            DeleteBoat(id, out oldBoat);
            _boatList.Add(boat.Id, boat);
        }
        // Find a boat by id and return the boat with that id
        // Throws an exception if the argument doesnt exist

        public Boat GetBoatById(int id)
        {
            if (!_boatList.ContainsKey(id))
            {
                throw new BadBoat.FaultyId($"Boat with ID {id} doesn't exist");
            }

            return _boatList[id];
        }

        // Så man kan finde både ud fra type

        public List<Boat> GetBoatByEnum(BoatType boatEnum)
        {
            List<Boat> list = new List<Boat>();

            foreach (KeyValuePair<int, Boat> kvp in _boatList)
            {
                Boat boat = kvp.Value;
                if (boat.Type == boatEnum)
                {
                    list.Add(boat);
                }
            }
            return list;
        }

        // Method to get all Boat objects in List form.
        public List<Boat> GetAllBoats()
        {
            return _boatList.Values.ToList();
        }
    }
}
