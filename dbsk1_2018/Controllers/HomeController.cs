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
        public IActionResult Indea()
        {
            string text = "Hello World";
            int number = 2;
            ViewBag.HelloText = text;
            ViewBag.ANumber = number;
            
            return View("Index");
        }

        // index refererar till en fil i view (ex.Index() --> Index.cshtml
        // funktion i controller som forms elr URL i php
        // return view, tänk echo i php
        //varje function  icontroller, ungefär issset i php (action=Indea())
        public IActionResult Index()
        {

            string test = "just a tst";
            ViewBag.test = test;

            return View();
        }
    }
}
