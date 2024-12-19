using hillerodLib.Models;
using hillerodLib.Services.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodWeb.Pages.BoatPages
{
    public class BoatPageModel : PageModel
    {
        private readonly BoatRepo _boatRepo;

        public Boat Boat { get; set; }

        public BoatPageModel(BoatRepo boatRepo)
        {
            _boatRepo = boatRepo;
        }

        public void OnGet(int id)
        {
            // Retrieve the boat with the given ID
            Boat = _boatRepo.GetBoatById(id);
        }
    }
}
