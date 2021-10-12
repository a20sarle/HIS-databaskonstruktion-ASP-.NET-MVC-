using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk9_2018.Models;

namespace dbsk9_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SomeText = "Some text passed from the controller using the ViewBag";
            return View();
        }
    }
}
