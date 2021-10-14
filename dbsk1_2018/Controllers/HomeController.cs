﻿using System;
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
        //private dropdownListrad sp = new dropdownListrad();
        //https://dugga.iit.his.se/DuggaSys/codeviewer.php?exampleid=6173&courseid=4&coursename=Databaskonstruktion&cvers=22521&lid=10279

        public IActionResult Update(string upd_artal, int upd_levererad)
        {
            // används till update av önskelistor.levererad
           sm.Update(upd_artal, upd_levererad);
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
            ViewBag.dropdownListrad = sm.dropdownListradArtal();
            //ViewBag.dropdownListrad = sp.dropdownListradArtal();
            return View();
        }

        
        public IActionResult dropdownListradArtal(string visa_artal)
        {
            ViewBag.onskelista = sm.GetOnskelista();
            ViewBag.onskelistaLevererade = sm.GetOnskelistaLevererade();
            ViewBag.dropdownListrad = sm.dropdownListradArtal();
            ViewBag.SearchResults = sm.visaOnskelistaDetaljer(visa_artal);
            return View("Index");
            // return RedirectToAction("Index");
        }
    }
}
