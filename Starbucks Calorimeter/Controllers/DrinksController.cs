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

        public async Task<IActionResult> Calories(string drinkName)
        {
            var drink = await drinkManager.GetDrink(drinkName);

            /*Когда буду делать бафы, то создавать new Drink() с данными, 
             *полученными с бд + Добавки (методы пост или хз)
             и уже этот новый drink передавать во View()*/

            return View(drink);
        }
    }
}
