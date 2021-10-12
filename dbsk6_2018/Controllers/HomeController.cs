using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk6_2018.Models;

namespace dbsk6_2018.Controllers
{
    public class HomeController : Controller
    {
        private InvoiceRowsModel sm = new InvoiceRowsModel();
        private CustomersModel sp = new CustomersModel();

        public IActionResult Index()
        {
            ViewBag.AllCustomersTable = sp.GetAllCustomers();
            return View();
        }

        public IActionResult SearchInvoiceRows(string custno)
        {
            ViewBag.SearchResults = sm.SearchInvoiceRows(custno);
            return View();
        }
    }
}
