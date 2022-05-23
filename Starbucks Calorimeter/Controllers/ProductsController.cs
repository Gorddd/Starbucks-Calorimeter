using Microsoft.AspNetCore.Mvc;
using Starbucks_Calorimeter.Managers.BottledDrinks;
using Starbucks_Calorimeter.Managers.Desserts;
using Starbucks_Calorimeter.Managers.FoodInPackages;
using Starbucks_Calorimeter.Managers.LunchAndBreakfasts;
using Starbucks_Calorimeter.Managers.Pastries;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Controllers
{
    public class ProductsController : Controller
    {
        private IDessertManager dessertManager;
        private IBottledDrinkManager bottledDrinkManager;
        private IFoodInPackageManager foodInPackageManager;
        private ILunchAndBreakfastManager lunchAndBreakfastManager;
        private IPastryManager pastryManager;

        public ProductsController(IDessertManager dessertManager, IBottledDrinkManager bottledDrinkManager, 
            IFoodInPackageManager foodInPackageManager, ILunchAndBreakfastManager lunchAndBreakfastManager, 
            IPastryManager pastryManager)
        {
            this.dessertManager = dessertManager;
            this.bottledDrinkManager = bottledDrinkManager;
            this.foodInPackageManager = foodInPackageManager;
            this.lunchAndBreakfastManager = lunchAndBreakfastManager;
            this.pastryManager = pastryManager;
        }

        public async Task<IActionResult> CaloriesAsync(string tableName, string name)
        {
            object product = new object();

            switch (tableName)
            {
                case "Desserts":
                    product = await dessertManager.Get(name);
                    break;
                case "BottledDrinks":
                    product = await bottledDrinkManager.Get(name);
                    break;
                case "FoodInPackages":
                    product = await foodInPackageManager.Get(name);
                    break;
                case "LunchAndBreakfasts":
                    product = await lunchAndBreakfastManager.Get(name);
                    break;
                case "Pastries":
                    product = await pastryManager.GetPastry(name);
                    break;
                default:
                    throw new ArgumentException("Неверное имя таблицы!");
            }

            return View(product);
        }
    }
}
