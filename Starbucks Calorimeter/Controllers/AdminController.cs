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
        IUserManager manager;

        public AdminController(IUserManager manager)
        {
            this.manager = manager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            var admin = manager.GetUser(user);
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

            return RedirectToAction(nameof(AdminPanel));
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

            var admin = manager.GetUser(new User { Login = login, Password = oldPassword });
            if (admin is null)
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction(nameof(Login));
            }

            admin.Password = newPassword;
            await manager.UpdateUser(admin);

            return RedirectToAction(nameof(AdminPanel));
        }

        [Authorize(Roles = "admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
