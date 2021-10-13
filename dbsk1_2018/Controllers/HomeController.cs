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
        private StudentsModel sm = new StudentsModel();
        public IActionResult Insert(string onskelista_artal, string onskelista_beskrivning, int onskelista_levererad)
        {
            sm.Insert(onskelista_artal, onskelista_beskrivning, onskelista_levererad);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            // StudentsModel sm = new StudentsModel();

            ViewBag.onskelista = sm.GetOnskelista();
            ViewBag.onskelistaLevererade = sm.GetOnskelistaLevererade();

            return View();
        }
    }
}
