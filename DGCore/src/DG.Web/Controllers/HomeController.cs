using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DG.Web.Models;
using DG.EntityFramework;
using DG.Core.Entities;
using DG.Application;
using Microsoft.Extensions.Logging;

namespace DG.Web.Controllers
{
    public class HomeController : Controller
    {
        private MenuService _service;
        public HomeController(MySqlDbContext dbcontext)
        {
            _service = new MenuService(dbcontext,new LoggerFactory());
        }
        public IActionResult Index()
        {
            var model= _service.GetAll();
            var pp = _service.CheangeUrl(1, "/sd/ss");
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
