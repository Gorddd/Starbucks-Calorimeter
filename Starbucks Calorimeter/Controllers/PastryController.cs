using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class PastryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
