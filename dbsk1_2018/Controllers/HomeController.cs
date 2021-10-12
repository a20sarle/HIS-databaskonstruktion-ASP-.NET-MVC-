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
            StudentsModel sm = new StudentsModel();
            ViewBag.onskelista = sm.GetOnskelista();

            return View();
        }
    }
}
