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

        public IActionResult Update(string upd_artal, int upd_levererad)
        {
            // används till update av önskelistor.levererad
           sm.Update(upd_artal, upd_levererad);
           return RedirectToAction("Index");
        }

        public IActionResult Move(string move_artal, int move_levererad, string move_beskrivning)
        {
            sm.Move(move_artal, move_levererad, move_beskrivning);
            return RedirectToAction("Index");
        }

        public IActionResult Insert(string onskelista_artal, string onskelista_beskrivning, int onskelista_levererad)
        {
            // används till insert av önskelistor
            sm.Insert(onskelista_artal, onskelista_beskrivning, onskelista_levererad);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            // hämtar tabeller 'onskelista' & 'onskelistaLevererade'
            ViewBag.onskelista = sm.GetOnskelista();
            ViewBag.onskelistaLevererade = sm.GetOnskelistaLevererade();
            ViewBag.dropdownListrad = sm.dropdownListradArtalModel();
            ViewBag.byggarnisseOne = sm.GetByggarnisseDetaljer();
            //ViewBag.dropdownListrad = sp.dropdownListradArtal();
            return View();
        }
        
        public IActionResult dropdownListradArtal(string visa_artal)
        {
            ViewBag.onskelista = sm.GetOnskelista();
            ViewBag.onskelistaLevererade = sm.GetOnskelistaLevererade();
            ViewBag.dropdownListrad = sm.dropdownListradArtalModel();
            ViewBag.SearchResults = sm.visaOnskelistaDetaljer(visa_artal);
            return View("Index");
        }


        public IActionResult byggarnisseDetaljer(int byggarnisse_idnr)
        {
            ViewBag.byggarnisse = sm.byggarnisseDetaljer(byggarnisse_idnr);
            //ViewBag.byggarnisse = sm.byggarnisseDetaljer(1); dubbelkolla om modellen kördes rätt

            return View();
        }
    }
}
