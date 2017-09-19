using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DG.Web.Models;
using DGCore.ChineseCalendar;

namespace DG.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new IndexVM()
            {
                ChineseCalendarInfo = CNCalendarHelper.GetChineseCalendar(DateTime.Now)
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "dldg";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "dldg";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
