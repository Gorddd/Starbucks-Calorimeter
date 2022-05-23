using Microsoft.AspNetCore.Mvc;
using Starbucks_Calorimeter.Managers.Drinks;
using Starbucks_Calorimeter.Managers.Espressoes;
using Starbucks_Calorimeter.Managers.Syrops;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Controllers
{
    public class DrinksController : Controller
    {
        IDrinkManager drinkManager;
        IEspressoManager espressoManager;
        ISyropManager syropManager;

        public DrinksController(IDrinkManager drinkManager, IEspressoManager espressoManager, ISyropManager syropManager)
        {
            this.drinkManager = drinkManager;
            this.espressoManager = espressoManager;
            this.syropManager = syropManager;
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
        public async Task<IActionResult> Calories(int drinkId, int espCount, int espDecafCount, int espBlondeCount)
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

            if (espDecafCount > 0)
            {
                var espresso = await espressoManager.Get(2); //Get Decaff shot

                for (int i = 0; i < espDecafCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Эспрессо Декаф Шоты", espDecafCount);
            }

            if (espBlondeCount > 0)
            {
                var espresso = await espressoManager.Get(3); //Get Blond shot

                for (int i = 0; i < espBlondeCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Блонд Эспрессо Шоты", espBlondeCount);
            }

            ViewBag.espShots = espressoShots; //Словарь: key - название шота, value - количество
            return View(drink);
        }

        //Получение сиропов с блока добавки
        [HttpPost]
        [Route("Drinks/Calories/{drinkId}/{malinCount}/{mindalCount}/{chocolateCount}/{vanillaCount}/{irelandCount}/{caramelCount}/{coconutCount}/{nutCount}")]
        public async Task<IActionResult> Calories(int drinkId, int malinCount, int mindalCount,
            int chocolateCount, int vanillaCount, int irelandCount, int caramelCount, int coconutCount, int nutCount)
        {
            var drink = await drinkManager.GetDrink(drinkId);

            var syrops = new Dictionary<string, int>();

            if (malinCount > 0)
            {
                var syrop = await syropManager.GetSyrop(1);

                for (int i = 0; i < malinCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Малиновый", malinCount);
            }

            if (mindalCount > 0)
            {
                var syrop = await syropManager.GetSyrop(2);

                for (int i = 0; i < mindalCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Миндальный", mindalCount);
            }

            if (chocolateCount > 0)
            {
                var syrop = await syropManager.GetSyrop(3);

                for (int i = 0; i < chocolateCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Шоколадный", chocolateCount);
            }

            if (vanillaCount > 0)
            {
                var syrop = await syropManager.GetSyrop(4);

                for (int i = 0; i < vanillaCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ванильный", vanillaCount);
            }

            if (irelandCount > 0)
            {
                var syrop = await syropManager.GetSyrop(5);

                for (int i = 0; i < irelandCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ирландский", irelandCount);
            }

            if (caramelCount > 0)
            {
                var syrop = await syropManager.GetSyrop(6);

                for (int i = 0; i < caramelCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Карамельный", caramelCount);
            }

            if (coconutCount > 0)
            {
                var syrop = await syropManager.GetSyrop(7);

                for (int i = 0; i < coconutCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Кокосовый", coconutCount);
            }

            if (nutCount > 0)
            {
                var syrop = await syropManager.GetSyrop(8);

                for (int i = 0; i < nutCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ореховый", nutCount);
            }

            ViewBag.syrops = syrops;
            return View();
        }
    }
}
