using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo.ASP
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "yeet";
            return View();
        }
    }
}
