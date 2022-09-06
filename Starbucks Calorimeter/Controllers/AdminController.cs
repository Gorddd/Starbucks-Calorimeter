using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Starbucks_Calorimeter.Managers;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Controllers
{
    public class AdminController : Controller
    {
        IAdminManager manager;
        public AdminController(IAdminManager manager)
        {
            this.manager = manager;
        }

        #region authorization

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            var admin = manager.UserManager.GetUser(user);
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

            var admin = manager.UserManager.GetUser(new User { Login = login, Password = oldPassword });
            if (admin is null)
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction(nameof(Login));
            }

            admin.Password = newPassword;
            await manager.UserManager.UpdateUser(admin);

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
            var users = await manager.UserManager.GetAll();

            return View(users);
        }

        //Фильтрация по логину
        [HttpPost]
        public async Task<IActionResult> UsersAsync(string login)
        {
            var users = await manager.UserManager.Filter(login);

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await manager.UserManager.AddUser(user);

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await manager.UserManager.DeleteUser(id);

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await manager.UserManager.UpdateUser(user);

            return RedirectToAction("Users");
        }
        #endregion

        #region Sizes

        //Все размеры
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SizesAsync()
        {
            var sizes = await manager.SizeManager.GetAll();

            return View(sizes);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> SizesAsync(string name)
        {
            var sizes = await manager.SizeManager.Filter(name);

            return View(sizes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSize(Size size)
        {
            await manager.SizeManager.AddSize(size);

            return RedirectToAction("Sizes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSize(int id)
        {
            await manager.SizeManager.DeleteSize(id);

            return RedirectToAction("Sizes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSize(Size size)
        {
            await manager.SizeManager.UpdateSize(size);

            return RedirectToAction("Sizes");
        }
        #endregion

        #region Syrops

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SyropsAsync()
        {
            var syrops = await manager.SyropManager.GetAll();

            return View(syrops);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> SyropsAsync(string name)
        {
            var sizes = await manager.SyropManager.Filter(name);

            return View(sizes);
        }

        [HttpPost]
        public async Task<IActionResult> AddSyrop(Syrop syrop)
        {
            await manager.SyropManager.AddSyrop(syrop);

            return RedirectToAction("Syrops");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSyrop(int id)
        {
            await manager.SyropManager.DeleteSyrop(id);

            return RedirectToAction("Syrops");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSyrop(Syrop syrop)
        {
            await manager.SyropManager.UpdateSyrop(syrop);

            return RedirectToAction("Syrops");
        }
        #endregion

        #region LunchAndBreakfasts

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> LunchAndBreakfastsAsync()
        {
            var lab = await manager.LunchAndBreakfastManager.GetAll();

            return View(lab);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> LunchAndBreakfastsAsync(string name)
        {
            var lab = await manager.LunchAndBreakfastManager.Filter(name);

            return View(lab);
        }

        [HttpPost]
        public async Task<IActionResult> AddLunchAndBreakfast(LunchAndBreakfast lunchAndBreakfast)
        {
            await manager.LunchAndBreakfastManager.Add(lunchAndBreakfast);

            return RedirectToAction("LunchAndBreakfasts");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLunchAndBreakfast(int id)
        {
            await manager.LunchAndBreakfastManager.Delete(id);

            return RedirectToAction("LunchAndBreakfasts");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLunchAndBreakfast(LunchAndBreakfast lunchAndBreakfast)
        {
            await manager.LunchAndBreakfastManager.Update(lunchAndBreakfast);

            return RedirectToAction("LunchAndBreakfasts");
        }
        #endregion

        #region FoodInPackages

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> FoodInPackagesAsync()
        {
            var fip = await manager.FoodInPackageManager.GetAll();

            return View(fip);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> FoodInPackagesAsync(string name)
        {
            var fip = await manager.FoodInPackageManager.Filter(name);

            return View(fip);
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodInPackage(FoodInPackage foodInPackage)
        {
            await manager.FoodInPackageManager.Add(foodInPackage);

            return RedirectToAction("FoodInPackages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFoodInPackage(int id)
        {
            await manager.FoodInPackageManager.Delete(id);

            return RedirectToAction("FoodInPackages");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFoodInPackages(FoodInPackage foodInPackage)
        {
            await manager.FoodInPackageManager.Update(foodInPackage);

            return RedirectToAction("FoodInPackages");
        }
        #endregion

        #region Espressoes

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EspressoesAsync()
        {
            var espresso = await manager.EspressoManager.GetAll();

            return View(espresso);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> EspressoesAsync(string name)
        {
            var espresso = await manager.EspressoManager.Filter(name);

            return View(espresso);
        }

        [HttpPost]
        public async Task<IActionResult> AddEspresso(Espresso espresso)
        {
            await manager.EspressoManager.Add(espresso);

            return RedirectToAction("Espressoes");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEspresso(int id)
        {
            await manager.EspressoManager.Delete(id);

            return RedirectToAction("Espressoes");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEspresso(Espresso espresso)
        {
            await manager.EspressoManager.Update(espresso);

            return RedirectToAction("Espressoes");
        }
        #endregion

        #region Desserts

        //Все сиропы
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DessertsAsync()
        {
            var dessert = await manager.DessertManager.GetAll();

            return View(dessert);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> DessertsAsync(string name)
        {
            var dessert = await manager.DessertManager.Filter(name);

            return View(dessert);
        }

        [HttpPost]
        public async Task<IActionResult> AddDessert(Dessert dessert)
        {
            await manager.DessertManager.Add(dessert);

            return RedirectToAction("Desserts");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDessert(int id)
        {
            await manager.DessertManager.Delete(id);

            return RedirectToAction("Desserts");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDessert(Dessert dessert)
        {
            await manager.DessertManager.Update(dessert);

            return RedirectToAction("Desserts");
        }
        #endregion

        #region Creams

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreamsAsync()
        {
            var cream = await manager.CreamManager.GetAll();

            return View(cream);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> CreamsAsync(string name)
        {
            var cream = await manager.CreamManager.Filter(name);

            return View(cream);
        }

        [HttpPost]
        public async Task<IActionResult> AddCream(Cream cream)
        {
            await manager.CreamManager.Add(cream);

            return RedirectToAction("Creams");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCream(int id)
        {
            await manager.CreamManager.Delete(id);

            return RedirectToAction("Creams");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCream(Cream cream)
        {
            await manager.CreamManager.Update(cream);

            return RedirectToAction("Creams");
        }
        #endregion

        #region BottledDrinks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BottledDrinksAsync()
        {
            var bottledDrinks = await manager.BottledDrinkManager.GetAll();

            return View(bottledDrinks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> BottledDrinkssAsync(string name)
        {
            var bottleddrink = await manager.BottledDrinkManager.Filter(name);

            return View(bottleddrink);
        }

        [HttpPost]
        public async Task<IActionResult> AddBottledDrink(BottledDrink bottledDrink)
        {
            await manager.BottledDrinkManager.Add(bottledDrink);

            return RedirectToAction("BottledDrinks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBottledDrink(int id)
        {
            await manager.BottledDrinkManager.Delete(id);

            return RedirectToAction("BottledDrinks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBottledDrink(BottledDrink bottledDrink)
        {
            await manager.BottledDrinkManager.Update(bottledDrink);

            return RedirectToAction("BottledDrinks");
        }
        #endregion

        #region Milks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> MilksAsync()
        {
            var milks = await manager.MilkManager.GetAll();

            return View(milks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> MilksAsync(string name)
        {
            var milk = await manager.MilkManager.Filter(name);

            return View(milk);
        }

        [HttpPost]
        public async Task<IActionResult> AddMilk(Milk milk)
        {
            await manager.MilkManager.Add(milk);

            return RedirectToAction("Milks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMilk(int id)
        {
            await manager.MilkManager.Delete(id);

            return RedirectToAction("Milks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMilk(Milk milk)
        {
            await manager.MilkManager.Update(milk);

            return RedirectToAction("Milks");
        }
        #endregion

        #region Drinks

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DrinksAsync()
        {
            var drinks = await manager.DrinkManager.GetAll();

            return View(drinks);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> DrinksAsync(string name)
        {
            var drink = await manager.DrinkManager.Filter(name);

            return View(drink);
        }

        [HttpPost]
        public async Task<IActionResult> AddDrink(Drink drink)
        {
            await manager.DrinkManager.AddDrink(drink);

            return RedirectToAction("Drinks");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            await manager.DrinkManager.DeleteDrink(id);

            return RedirectToAction("Drinks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrink(Drink drink)
        {
            await manager.DrinkManager.UpdateDrink(drink);

            return RedirectToAction("Drinks");
        }
        #endregion

        #region Pastry

        //Все крема
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PastriesAsync()
        {
            var dpastry = await manager.PastryManager.GetAll();

            return View(dpastry);
        }

        //Фильтрация по названию
        [HttpPost]
        public async Task<IActionResult> PastriesAsync(string name)
        {
            var pastry = await manager.PastryManager.Filter(name);

            return View(pastry);
        }

        [HttpPost]
        public async Task<IActionResult> AddPastry(Pastry pastry)
        {
            await manager.PastryManager.AddPastry(pastry);

            return RedirectToAction("Pastries");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePastry(int id)
        {
            await manager.PastryManager.DeletePastry(id);

            return RedirectToAction("Pastries");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePastry(Pastry pastry)
        {
            await manager.PastryManager.UpdatePastry(pastry);

            return RedirectToAction("Pastries");
        }
        #endregion
    }
}
