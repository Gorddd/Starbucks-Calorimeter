using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class LunchAndBreakfastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
