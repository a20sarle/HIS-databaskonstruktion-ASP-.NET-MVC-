using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk1_2018.Models;

namespace dbsk1_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string text = "Hello World";
            int number = 2;
            ViewBag.HelloText = text;
            ViewBag.ANumber = number;

            string test = "just a tst";            
            ViewBag.test = test;
            
            return View();
        }
    }
}
