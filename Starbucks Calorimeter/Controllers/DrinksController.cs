using Microsoft.AspNetCore.Mvc;
using Starbucks_Calorimeter.Managers.Drinks;

namespace Starbucks_Calorimeter.Controllers
{
    public class DrinksController : Controller
    {
        IDrinkManager drinkManager;

        public DrinksController(IDrinkManager drinkManager)
        {
            this.drinkManager = drinkManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calories(string drinkName)
        {
            var drink = drinkManager.GetDrink(drinkName);

            return View(drink);
        }
    }
}
