using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hillerodLib.Services;
using hillerodLib.Models;
using hillerodLib.Services.Repos;
using hillerodLib.Enums;


namespace hillerodsejlklubWebApp.Pages.BoatPages
{
    public class BoatPageModel : PageModel
    {
        private readonly BoatRepo _repo;

        public List<Boat> Boats { get; set; } 

        

        public BoatPageModel(BoatRepo repo)
        {
            _repo = repo;
            _repo.AddBoat(new(1, "Molly", BoatType.SailBoat, "Beneteau395", "395", "Yanmar 4JH4", 12, "2018")); // Boat test
            _repo.AddBoat(new(2, "Dori", BoatType.SailBoat, "Shantau245", "245", "Volvo 4kMA", 14, "2014")); // Boat test
            _repo.AddBoat(new(3, "Maren", BoatType.SailBoat, "Nimbus 405 Coupe", "N405", "2 x Volvo Penta 380HK", 16, "2020"));
        }

        public void OnGet()
        {
            Boats = _repo.GetAllBoats();
            
        }
    }
}
