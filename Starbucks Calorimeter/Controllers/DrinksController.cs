using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class DrinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
