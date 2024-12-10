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

        // Så man kan tilføje en båd
        public void AddBoat(Boat boat)

        {
            _boatList.TryAdd(boat.Id, boat);
        }

        // Så man kan slette en båd
        public bool DeleteBoat(int boatId, out Boat deleteBoat)
        {
            return _boatList.Remove(boatId, out deleteBoat);

        }

        // Så man kan opdatere en båd
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

        // Så man kan finde en båd på Id nummer

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
