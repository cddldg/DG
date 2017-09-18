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

namespace DG.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _myContext; //#构造函数注入
        public HomeController(MyContext dbCon)
        {
            _myContext = dbCon;
        }
        public IActionResult Index()
        {
            var entity = new Category() {  SysNo=1, Title="百", Description="asfas"};
            var model = _myContext.Categories.Add(entity);
            _myContext.SaveChanges();
            var list = _myContext.Categories.FirstOrDefault();
           return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
