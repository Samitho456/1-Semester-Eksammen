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
                _boatList[id].Name = boat.Name;
                _boatList[id].Engine = boat.Engine;
                _boatList[id].SailNumber = boat.SailNumber;
                _boatList[id].Type = boat.Type;
                _boatList[id].Measures = boat.Measures;
                _boatList[id].BuildingYear = boat.BuildingYear;
                _boatList[id].Model = boat.Model;
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

         // Så man kan finde både ud fra type

            List<Boat> GetBoatByEnum(BoatType boatEnum)
            {
                List<Boat> list = new List<Boat>();

                foreach (KeyValuePair<int, Boat> kvp in _boatList)
                {
                    Boat boat = kvp.Value;
                    if (boat.Type == boatEnum)
                        list.Add(boat);
                }
                return list;
            }
        }
    }
}
