using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk7_2018.Models;

namespace dbsk7_2018.Controllers
{
    public class HomeController : Controller
    {
        private CustomersModel sp = new CustomersModel();

        public IActionResult Index()
        {
            ViewBag.CustomerTable = sp.GetAllCustomers();
            return View();
        }

        public IActionResult InsertCustomer(string custno, string ssn,string name)
        {
            sp.InsertCustomer(custno,ssn,name);
            return RedirectToAction("Index");
        }

    }
}
