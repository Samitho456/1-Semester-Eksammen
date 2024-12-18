using hillerodLib.Enums;
using hillerodLib.Services.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hillerodLib.MockData
{
    public static class MockData
    {
        public static BoatRepo _boatRepo;

        static MockData()
        {
            _boatRepo = new BoatRepo();
            _boatRepo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018")); // Boat test
            _boatRepo.AddBoat(new(2, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014")); // Boat test
            _boatRepo.AddBoat(new(3, "Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020"));
        }
    }
}
