using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Starbucks_Calorimeter.Managers.Users;
using Starbucks_Calorimeter.Models.Entity;
using Starbucks_Calorimeter.Managers.Sizes;
using Starbucks_Calorimeter.Managers.Syrops;
using Starbucks_Calorimeter.Managers.LunchAndBreakfasts;
using Starbucks_Calorimeter.Managers.FoodInPackages;
using Starbucks_Calorimeter.Managers.Espressoes;
using Starbucks_Calorimeter.Managers.Desserts;
using Starbucks_Calorimeter.Managers.Creams;
using Starbucks_Calorimeter.Managers.BottledDrinks;
using Starbucks_Calorimeter.Managers.Milks;
using Starbucks_Calorimeter.Managers.Drinks;
using Starbucks_Calorimeter.Managers.Pastries;

namespace Starbucks_Calorimeter.Controllers
{
    public class AdminController : Controller
    {
        IUserManager userManager;
        ISizeManager sizeManager;
        ISyropManager syropManager;
        ILunchAndBreakfastManager lunchAndBreakfastManager;
        IFoodInPackageManager foodInPackageManager;
        IEspressoManager espressoManager;
        IDessertManager dessertManager;
        ICreamManager creamManager;
        IBottledDrinkManager bottledDrinkManager;
        IMilkManager milkManager;
        IDrinkManager drinkManager;
        IPastryManager pastryManager;

        public AdminController(IUserManager userManager, ISizeManager sizeManager,
            ISyropManager syropManager, ILunchAndBreakfastManager lunchAndBreakfastManager,
            IFoodInPackageManager foodInPackageManager, IEspressoManager espressoManager,
            IDessertManager dessertManager, ICreamManager creamManager, IBottledDrinkManager bottledDrinkManager,
            IMilkManager milkManager, IDrinkManager drinkManager, IPastryManager pastryManager)
        {
            this.userManager = userManager;
            this.sizeManager = sizeManager;
            this.syropManager = syropManager;
            this.lunchAndBreakfastManager = lunchAndBreakfastManager;
            this.foodInPackageManager = foodInPackageManager;
            this.espressoManager = espressoManager;
            this.dessertManager = dessertManager;
            this.creamManager = creamManager;
            this.bottledDrinkManager = bottledDrinkManager;
            this.milkManager = milkManager;
            this.drinkManager = drinkManager;
            this.pastryManager = pastryManager;
         }

        #region authorization

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            var admin = userManager.GetUser(user);
            if (admin is null)
                return RedirectToAction(nameof(Login));

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Login)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        [Authorize(Roles = "admin")]
        public IActionResult ChangePassword()
        {
            ViewBag.Login = HttpContext.User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var login = HttpContext.User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);

            var admin = userManager.GetUser(new User { Login = login, Password = oldPassword });
            if (admin is null)
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction(nameof(Login));
            }

            admin.Password = newPassword;
            await userManager.UpdateUser(admin);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region Users

        //Все юзеры
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UsersAsync()
        {
            var users = await userManager.GetAll();

            return View(users);
        }

        //Фильтрация по логину
        [HttpPost]
        public async Task<IActionResult> UsersAsync(string login)
        {
            var users = await userManager.Filter(login);

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await userManager.AddUser(user);

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userManager.DeleteUser(id);

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await userManager.UpdateUser(user);

            return RedirectToAction("Users");
        }
        #endregion

        #region Sizes

        //Все размеры
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SizesAsync()
        {
            var sizes = await sizeManager.GetAll();

            return View(sizes);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> SizesAsync(string name)
        {
            var sizes = await sizeManager.Filter(name);

            return View(sizes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSize(Size size)
        {
            await sizeManager.AddSize(size);

            return RedirectToAction("Sizes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSize(int id)
        {
            await sizeManager.DeleteSize(id);

            return RedirectToAction("Sizes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSize(Size size)
        {
            await sizeManager.UpdateSize(size);

            return RedirectToAction("Sizes");
        }
        #endregion

        #region Syrops

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SyropsAsync()
        {
            var syrops = await syropManager.GetAll();

            return View(syrops);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> SyropsAsync(string name)
        {
            var sizes = await syropManager.Filter(name);

            return View(sizes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSyrop(Syrop syrop)
        {
            await syropManager.AddSyrop(syrop);

            return RedirectToAction("Syrops");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSyrop(int id)
        {
            await syropManager.DeleteSyrop(id);

            return RedirectToAction("Syrops");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSyrop(Syrop syrop)
        {
            await syropManager.UpdateSyrop(syrop);

            return RedirectToAction("Syrops");
        }
        #endregion

        #region LunchAndBreakfasts

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> LunchAndBreakfastsAsync()
        {
            var lab = await lunchAndBreakfastManager.GetAll();

            return View(lab);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> LunchAndBreakfastsAsync(string name)
        {
            var lab = await lunchAndBreakfastManager.Filter(name);

            return View(lab);
        }

        [HttpPost]
        public async Task<IActionResult> AddLunchAndBreakfast(LunchAndBreakfast lunchAndBreakfast)
        {
            await lunchAndBreakfastManager.Add(lunchAndBreakfast);

            return RedirectToAction("LunchAndBreakfasts");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLunchAndBreakfast(int id)
        {
            await lunchAndBreakfastManager.Delete(id);

            return RedirectToAction("LunchAndBreakfasts");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLunchAndBreakfast(LunchAndBreakfast lunchAndBreakfast)
        {
            await lunchAndBreakfastManager.Update(lunchAndBreakfast);

            return RedirectToAction("LunchAndBreakfasts");
        }
        #endregion

        #region FoodInPackages

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> FoodInPackagesAsync()
        {
            var fip = await foodInPackageManager.GetAll();

            return View(fip);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> FoodInPackagesAsync(string name)
        {
            var fip = await foodInPackageManager.Filter(name);

            return View(fip);
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodInPackage(FoodInPackage foodInPackage)
        {
            await foodInPackageManager.Add(foodInPackage);

            return RedirectToAction("FoodInPackages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodInPackage(int id)
        {
            await foodInPackageManager.Delete(id);

            return RedirectToAction("FoodInPackages");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodInPackages(FoodInPackage foodInPackage)
        {
            await foodInPackageManager.Update(foodInPackage);

            return RedirectToAction("FoodInPackages");
        }
        #endregion

        #region Espressoes

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EspressoesAsync()
        {
            var espresso = await espressoManager.GetAll();

            return View(espresso);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> EspressoesAsync(string name)
        {
            var espresso = await espressoManager.Filter(name);

            return View(espresso);
        }

        [HttpPost]
        public async Task<IActionResult> AddEspresso(Espresso espresso)
        {
            await espressoManager.Add(espresso);

            return RedirectToAction("Espressoes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEspresso(int id)
        {
            await espressoManager.Delete(id);

            return RedirectToAction("Espressoes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEspresso(Espresso espresso)
        {
            await espressoManager.Update(espresso);

            return RedirectToAction("Espressoes");
        }
        #endregion

        #region Desserts

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DessertsAsync()
        {
            var dessert = await dessertManager.GetAll();

            return View(dessert);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> DessertsAsync(string name)
        {
            var dessert = await dessertManager.Filter(name);

            return View(dessert);
        }

        [HttpPost]
        public async Task<IActionResult> AddDessert(Dessert dessert)
        {
            await dessertManager.Add(dessert);

            return RedirectToAction("Desserts");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDessert(int id)
        {
            await dessertManager.Delete(id);

            return RedirectToAction("Desserts");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDessert(Dessert dessert)
        {
            await dessertManager.Update(dessert);

            return RedirectToAction("Desserts");
        }
        #endregion

        #region Creams

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreamsAsync()
        {
            var cream = await creamManager.GetAll();

            return View(cream);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> CreamsAsync(string name)
        {
            var cream = await creamManager.Filter(name);

            return View(cream);
        }

        [HttpPost]
        public async Task<IActionResult> AddCream(Cream cream)
        {
            await creamManager.Add(cream);

            return RedirectToAction("Creams");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCream(int id)
        {
            await creamManager.Delete(id);

            return RedirectToAction("Creams");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCream(Cream cream)
        {
            await creamManager.Update(cream);

            return RedirectToAction("Creams");
        }
        #endregion

        #region BottledDrinks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BottledDrinksAsync()
        {
            var bottledDrinks = await bottledDrinkManager.GetAll();

            return View(bottledDrinks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> BottledDrinkssAsync(string name)
        {
            var bottleddrink = await bottledDrinkManager.Filter(name);

            return View(bottleddrink);
        }

        [HttpPost]
        public async Task<IActionResult> AddBottledDrink(BottledDrink bottledDrink)
        {
            await bottledDrinkManager.Add(bottledDrink);

            return RedirectToAction("BottledDrinks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBottledDrink(int id)
        {
            await bottledDrinkManager.Delete(id);

            return RedirectToAction("BottledDrinks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBottledDrink(BottledDrink bottledDrink)
        {
            await bottledDrinkManager.Update(bottledDrink);

            return RedirectToAction("BottledDrinks");
        }
        #endregion

        #region Milks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> MilksAsync()
        {
            var milks = await milkManager.GetAll();

            return View(milks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> MilksAsync(string name)
        {
            var milk = await milkManager.Filter(name);

            return View(milk);
        }

        [HttpPost]
        public async Task<IActionResult> AddMilk(Milk milk)
        {
            await milkManager.Add(milk);

            return RedirectToAction("Milks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMilk(int id)
        {
            await milkManager.Delete(id);

            return RedirectToAction("Milks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMilk(Milk milk)
        {
            await milkManager.Update(milk);

            return RedirectToAction("Milks");
        }
        #endregion

        #region Drinks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DrinksAsync()
        {
            var drinks = await drinkManager.GetAll();

            return View(drinks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> DrinksAsync(string name)
        {
            var drink = await drinkManager.Filter(name);

            return View(drink);
        }

        [HttpPost]
        public async Task<IActionResult> AddDrink(Drink drink)
        {
            await drinkManager.AddDrink(drink);

            return RedirectToAction("Drinks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            await drinkManager.DeleteDrink(id);

            return RedirectToAction("Drinks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrink(Drink drink)
        {
            await drinkManager.UpdateDrink(drink);

            return RedirectToAction("Drinks");
        }
        #endregion

        #region Pastry

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PastriesAsync()
        {
            var dpastry = await pastryManager.GetAll();

            return View(dpastry);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> PastriesAsync(string name)
        {
            var pastry = await pastryManager.Filter(name);

            return View(pastry);
        }

        [HttpPost]
        public async Task<IActionResult> AddPastry(Pastry pastry)
        {
            await pastryManager.AddPastry(pastry);

            return RedirectToAction("Pastries");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePastry(int id)
        {
            await pastryManager.DeletePastry(id);

            return RedirectToAction("Pastries");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePastry(Pastry pastry)
        {
            await pastryManager.UpdatePastry(pastry);

            return RedirectToAction("Pastries");
        }
        #endregion
    }
}
