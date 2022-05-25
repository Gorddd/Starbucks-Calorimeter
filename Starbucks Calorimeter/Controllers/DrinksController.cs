using Microsoft.AspNetCore.Mvc;
using Starbucks_Calorimeter.Managers.Creams;
using Starbucks_Calorimeter.Managers.Drinks;
using Starbucks_Calorimeter.Managers.Espressoes;
using Starbucks_Calorimeter.Managers.Milks;
using Starbucks_Calorimeter.Managers.Syrops;

namespace Starbucks_Calorimeter.Controllers
{
    public class DrinksController : Controller
    {
        IDrinkManager drinkManager;
        IEspressoManager espressoManager;
        ISyropManager syropManager;
        IMilkManager milkManager;
        ICreamManager creamManager;
        DrinkView drinkView;

        public DrinksController(IDrinkManager drinkManager, 
            IEspressoManager espressoManager, 
            ISyropManager syropManager, 
            IMilkManager milkManager, 
            ICreamManager creamManager, 
            DrinkView drinkView)
        {
            this.drinkManager = drinkManager;
            this.espressoManager = espressoManager;
            this.syropManager = syropManager;
            this.milkManager = milkManager;
            this.creamManager = creamManager;
            this.drinkView = drinkView;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        //Заходим в новый напиток
        public async Task<IActionResult> GetDrink(string drinkName)
        {
            var drink = await drinkManager.GetDrink(drinkName);

            drinkView.Drink = drink;
            drinkView.espShots = null;//Очистка от старого
            drinkView.addedEspShots = null;

            return RedirectToAction(nameof(Calories));
        }

        //Выводим напиток
        public async Task<IActionResult> Calories()
        {
            ViewBag.espShots = drinkView.espShots;

            return View(drinkView.Drink);
        }


        //Получение с блока основа
        [HttpPost]
        public async Task<IActionResult> Basis(string? sizeName, string? espressoName, string? milkName)
        {
            drinkView.Drink = await drinkManager.GetDrink(drinkView.Drink.Name, 
                sizeName ?? drinkView.Drink.Size.Name, 
                espressoName ?? drinkView.Drink.Espresso?.Name, 
                milkName ?? drinkView.Drink.Milk?.Name);

            if (drinkView.espShots is not null)//прибавляем пищевую ценность с добавок
                foreach(var shot in drinkView.addedEspShots)
                    for (int i = 0; i < shot.Value; i++)
                        drinkView.Drink.AddNutritionalValue(shot.Key);

            return RedirectToAction(nameof(Calories));
        }

        //Получение эспрессо с блока добавки
        [HttpPost]
        public async Task<IActionResult> AddEspresso(int espCount, int espDecafCount, int espBlondeCount)
        {
            var drink = drinkView.Drink;

            if (drinkView.espShots is not null)//Очистка от предыдущего
                foreach (var esp in drinkView.addedEspShots)
                    for (int i = 0; i < esp.Value; i++)
                        drinkView.Drink.SubtractNutritionalValue(esp.Key);

            drinkView.espShots = null;
            drinkView.addedEspShots = null;

            if (espCount == 0 && espDecafCount == 0 && espBlondeCount == 0)
                return RedirectToAction(nameof(Calories));


            var espressoShots = new Dictionary<string, int>(3); //Словарь: key - название шота, value - количество
            drinkView.addedEspShots = new Dictionary<Models.Entity.Espresso, int>(3); //key - espresso, value - колво

            if (espCount > 0)
            {
                var espresso = await espressoManager.Get(1); //Get espresso shot

                for (int i = 0; i < espCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Эспрессо Шоты", espCount);
                drinkView.addedEspShots.Add(espresso, espCount);
            }

            if (espDecafCount > 0)
            {
                var espresso = await espressoManager.Get(2); //Get Decaff shot

                for (int i = 0; i < espDecafCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Эспрессо Декаф Шоты", espDecafCount);
                drinkView.addedEspShots.Add(espresso, espDecafCount);
            }

            if (espBlondeCount > 0)
            {
                var espresso = await espressoManager.Get(3); //Get Blond shot

                for (int i = 0; i < espBlondeCount; i++)
                    drink.AddNutritionalValue(espresso);

                espressoShots.Add("Блонд Эспрессо Шоты", espBlondeCount);
                drinkView.addedEspShots.Add(espresso, espBlondeCount);
            }


            drinkView.Drink = drink;
            drinkView.espShots = espressoShots;

            return RedirectToAction(nameof(Calories));
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
            return View(drink);
        }

        //Получение молока с блока добавки
        [HttpPost]
        [Route("Drinks/Calories/{drinkId}/{addmilkName}")]
        public async Task<IActionResult> Calories(int drinkId, string addmilkName)
        {
            var drink = await drinkManager.GetDrink(drinkId);

            var milk = await milkManager.Get(addmilkName);

            drink.AddNutritionalValue(milk);

            ViewBag.milkName = addmilkName;
            return View(drink);
        }

        [HttpPost]
        [Route("Drinks/Calories/{drinkId}/{drinkName}/{addCream}")]
        public async Task<IActionResult> Calories(int drinkId, string drinkName, string addCream)
        {
            if (drinkName is null)
            {
                throw new ArgumentNullException(nameof(drinkName));
            }

            var drink = await drinkManager.GetDrink(drinkId);

            var cream = await creamManager.Get(addCream);

            drink.AddNutritionalValue(cream);

            ViewBag.creamName = addCream;
            return View(drink);
        }
    }
}
