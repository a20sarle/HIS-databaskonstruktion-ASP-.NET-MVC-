using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbsk8_2018.Controllers
{
    public class Page2Controller : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new dbsk8_2018.Models.StudyProgramModel().GetAllStudyPrograms());
        }
    }
}
