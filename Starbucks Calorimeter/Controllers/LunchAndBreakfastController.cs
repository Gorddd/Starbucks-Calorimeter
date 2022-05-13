using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class LunchAndBreakfastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calories()
        {
            return View();
        }
    }
}
