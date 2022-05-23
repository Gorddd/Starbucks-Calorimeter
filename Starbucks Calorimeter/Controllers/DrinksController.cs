using Microsoft.AspNetCore.Mvc;
using Starbucks_Calorimeter.Managers.Drinks;
using Starbucks_Calorimeter.Managers.Espressoes;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Controllers
{
    public class DrinksController : Controller
    {
        IDrinkManager drinkManager;
        IEspressoManager espressoManager;

        public DrinksController(IDrinkManager drinkManager, IEspressoManager espressoManager)
        {
            this.drinkManager = drinkManager;
            this.espressoManager = espressoManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Calories(string drinkName)
        {
            var drink = await drinkManager.GetDrink(drinkName);

            return View(drink);
        }


        //Получение с блока основа
        [HttpPost]
        public async Task<IActionResult> Calories(int drinkId, string? sizeName, string? espressoName, string? milkName)
        {
            var drink = await drinkManager.GetDrink(drinkId);

            drink = await drinkManager.GetDrink(drink.Name, 
                sizeName ?? drink.Size.Name, 
                espressoName ?? drink.Espresso?.Name, 
                milkName ?? drink.Milk?.Name);

            return View(drink);
        }

        
        //Получение эспрессо с блока добавки
        [HttpPost]
        [Route("Drinks/Calories/{drinkId}/{espCount}/{espDecaffCount}/{espBlondCount}")]
        public async Task<IActionResult> Calories(int drinkId, int espCount, int espDecaffCount, int espBlondCount)
        {
            var drink = await drinkManager.GetDrink(drinkId);

            var espressoShots = new Dictionary<string, int>(3);

            if (espCount > 0)
            {
                var espresso = await espressoManager.Get(1); //Get espresso shot

                for (int i = 0; i < espCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Эспрессо Шоты", espCount);
            }

            if (espDecaffCount > 0)
            {
                var espresso = await espressoManager.Get(2); //Get Decaff shot

                for (int i = 0; i < espDecaffCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Эспрессо Декаф Шоты", espDecaffCount);
            }

            if (espBlondCount > 0)
            {
                var espresso = await espressoManager.Get(3); //Get Blond shot

                for (int i = 0; i < espBlondCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Блонд Эспрессо Шоты", espBlondCount);
            }

            ViewBag.espShots = espressoShots; //Словарь: key - название шота, value - количество
            return View(drink);
        }

        ////Получение сиропа с блока добавки
        //[HttpPost]

        //public async Task<IActionResult> Calories()
        //{

        //    return View();
        //}
    }
}
