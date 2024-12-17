using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib
{
    public class BoatRepo
    {
        private Dictionary<int, Boat> _boatList = new Dictionary<int, Boat>();

        // Add a boat to dictonary
        public void AddBoat(Boat boat)
        {
            _boatList.TryAdd(boat.Id, boat);
        }

        // Delete a boat by id and out the deleted boat
        public bool DeleteBoat(int boatId, out Boat deleteBoat)
        {
            return _boatList.Remove(boatId, out deleteBoat);
        }

        // Update boat with specific Id with a new boat
        public void UpdateBoat(int id, Boat boat)
        {
            if (_boatList.ContainsKey(id))
            {
                _boatList[id] = boat;
                
            }
        }

        // Find a boat by id and return the boat with that id
        // If no boat found, return null

        public Boat GetBoatById(int id)
        {
            if (_boatList.ContainsKey(id))
            {
                return _boatList[id];
            }
            return null;
        }
         // Find a boat by type, and return a list of boats by that type

        public List<Boat> GetBoatByEnum(BoatType boatEnum)
        {
            List<Boat> result = new List<Boat>();

            foreach (Boat boat in _boatList.Values)
            {
                if (boat.Type == boatEnum)
                    result.Add(boat);
            }
            return result;
        }

    }
}
