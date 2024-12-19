using hillerodLib.Enums;
using hillerodLib.Models;
using hillerodLib.MockData;
using hillerodLib.Services.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HillerodWeb.Pages.BoatPages
{
    public class BoatsModel : PageModel
    {
        
        public List<Boat> Boats { get; set; }


        public void OnGet()
        {

            Boats = MockData._boatRepo.GetAllBoats();
        }
    }
}
