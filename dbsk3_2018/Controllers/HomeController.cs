using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk3_2018.Models;

namespace dbsk3_2018.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MyModel anInstanceOfMyModel = new MyModel("Hello World", 3);
            ViewBag.HelloText = anInstanceOfMyModel.Text;
            ViewBag.ANumber = anInstanceOfMyModel.Number;
            ViewBag.FunnyString = anInstanceOfMyModel.TextMultipliedWithNumber();
            return View();
        }
    }
}
