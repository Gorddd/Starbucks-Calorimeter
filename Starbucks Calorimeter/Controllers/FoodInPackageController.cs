﻿using Microsoft.AspNetCore.Mvc;

namespace Starbucks_Calorimeter.Controllers
{
    public class FoodInPackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Food_calories()
        {
            return View();
        }


    }
}
