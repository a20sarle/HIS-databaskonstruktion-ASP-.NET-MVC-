using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk5_2018.Models;

namespace dbsk5_2018.Controllers
{
    public class HomeController : Controller
    {
        private CustomersModel sm = new CustomersModel();

        public IActionResult Index()
        {
            ViewBag.AllCustomersTable = sm.GetAllCustomers();
            return View();
        }

        public IActionResult DeleteCustomer(string custno)
        {
            sm.DeleteCustomer(custno);
            return RedirectToAction("Index");
        }

    }
}
