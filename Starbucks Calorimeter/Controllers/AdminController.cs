using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Starbucks_Calorimeter.Managers.Users;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Controllers
{
    public class AdminController : Controller
    {
        IUserManager userManager;

        public AdminController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

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

        #region Users

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UsersAsync()
        {
            var users = await userManager.GetAll();

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
    }
}
