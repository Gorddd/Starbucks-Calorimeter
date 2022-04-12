using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class BottledDrinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
