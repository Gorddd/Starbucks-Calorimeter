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
            drinkView.syrops = null;
            drinkView.addedSyrops = null;
            drinkView.MilkName = null;
            drinkView.addedMilk = null;
            drinkView.CreamName = null;
            drinkView.addedCream = null;

            return RedirectToAction(nameof(Calories));
        }

        //Выводим напиток
        public async Task<IActionResult> Calories()
        {
            ViewBag.espShots = drinkView.espShots;
            ViewBag.syrops = drinkView.syrops;
            ViewBag.milkName = drinkView.MilkName;
            ViewBag.creamName = drinkView.CreamName;

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

            if (drinkView.syrops is not null)
                foreach (var syr in drinkView.addedSyrops)
                    for (int i = 0; i < syr.Value; i++)
                        drinkView.Drink.AddNutritionalValue(syr.Key);

            if (drinkView.MilkName is not null)
                drinkView.Drink.AddNutritionalValue(drinkView.addedMilk);

            if (drinkView.CreamName is not null)
                drinkView.Drink.AddNutritionalValue(drinkView.addedCream);

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
        public async Task<IActionResult> AddSyrop(int malinCount, int mindalCount,
            int chocolateCount, int vanillaCount, int irelandCount, int caramelCount, int coconutCount, int nutCount)
        {
            var drink = drinkView.Drink;

            if (drinkView.syrops is not null)//Очистка от предыдущего
                foreach (var syr in drinkView.addedSyrops)
                    for (int i = 0; i < syr.Value; i++)
                        drinkView.Drink.SubtractNutritionalValue(syr.Key);

            drinkView.syrops = null;
            drinkView.addedSyrops = null;

            if (malinCount == 0 && mindalCount == 0 && chocolateCount == 0 && vanillaCount == 0 
                && irelandCount == 0 && caramelCount == 0 && coconutCount == 0 && nutCount == 0)
                return RedirectToAction(nameof(Calories));


            var syrops = new Dictionary<string, int>();
            drinkView.addedSyrops = new Dictionary<Models.Entity.Syrop, int>();

            if (malinCount > 0)
            {
                var syrop = await syropManager.GetSyrop(1);

                for (int i = 0; i < malinCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Малиновый", malinCount);
                drinkView.addedSyrops.Add(syrop, malinCount);
            }

            if (mindalCount > 0)
            {
                var syrop = await syropManager.GetSyrop(2);

                for (int i = 0; i < mindalCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Миндальный", mindalCount);
                drinkView.addedSyrops.Add(syrop, mindalCount);
            }

            if (chocolateCount > 0)
            {
                var syrop = await syropManager.GetSyrop(3);

                for (int i = 0; i < chocolateCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Шоколадный", chocolateCount);
                drinkView.addedSyrops.Add(syrop, chocolateCount);
            }

            if (vanillaCount > 0)
            {
                var syrop = await syropManager.GetSyrop(4);

                for (int i = 0; i < vanillaCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ванильный", vanillaCount);
                drinkView.addedSyrops.Add(syrop, vanillaCount);
            }

            if (irelandCount > 0)
            {
                var syrop = await syropManager.GetSyrop(5);

                for (int i = 0; i < irelandCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ирландский", irelandCount);
                drinkView.addedSyrops.Add(syrop, irelandCount);
            }

            if (caramelCount > 0)
            {
                var syrop = await syropManager.GetSyrop(6);

                for (int i = 0; i < caramelCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Карамельный", caramelCount);
                drinkView.addedSyrops.Add(syrop, caramelCount);
            }

            if (coconutCount > 0)
            {
                var syrop = await syropManager.GetSyrop(7);

                for (int i = 0; i < coconutCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Кокосовый", coconutCount);
                drinkView.addedSyrops.Add(syrop, coconutCount);
            }

            if (nutCount > 0)
            {
                var syrop = await syropManager.GetSyrop(8);

                for (int i = 0; i < nutCount; i++)
                    drink.AddNutritionalValue(syrop);

                syrops.Add("Ореховый", nutCount);
                drinkView.addedSyrops.Add(syrop, nutCount);
            }


            drinkView.Drink = drink;
            drinkView.syrops = syrops;

            return RedirectToAction(nameof(Calories));
        }

        //Получение молока с блока добавки
        [HttpPost]
        public async Task<IActionResult> AddMilk(string addmilkName)
        {
            var milk = await milkManager.Get(addmilkName);

            if (drinkView.MilkName is not null)//Очистка от предыдущего
                drinkView.Drink.SubtractNutritionalValue(drinkView.addedMilk);

            drinkView.Drink.AddNutritionalValue(milk);

            drinkView.addedMilk = milk;
            drinkView.MilkName = addmilkName;
            return RedirectToAction(nameof(Calories));
        }

        //Получение сливок с блока добавки
        [HttpPost]
        public async Task<IActionResult> AddCream(string addCream)
        {
            var cream = await creamManager.Get(addCream);

            if (drinkView.CreamName is not null)//Очистка от предыдущего
                drinkView.Drink.SubtractNutritionalValue(drinkView.addedCream);

            drinkView.Drink.AddNutritionalValue(cream);

            drinkView.addedCream = cream;
            drinkView.CreamName = addCream;
            return RedirectToAction(nameof(Calories));
        }
    }
}
