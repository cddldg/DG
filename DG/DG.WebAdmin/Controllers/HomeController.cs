using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DG.WebAdmin.Models;
using DG.Infrastructure;
using static DG.Infrastructure.MyContext;
using DG.Core.Entities;
using DGCore.ChineseCalendar;
using System.Text;

namespace DG.WebAdmin.Controllers
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
