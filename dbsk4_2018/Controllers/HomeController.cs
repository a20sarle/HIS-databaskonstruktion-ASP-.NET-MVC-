using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk4_2018.Models;

namespace dbsk4_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CustomersModel sm = new CustomersModel();
            ViewBag.CustomerTable = sm.GetAllCustomers();
            return View();
        }
    }
}