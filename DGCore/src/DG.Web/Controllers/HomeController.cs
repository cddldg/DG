using ACC.Application;
using ACC.AutoMapper;
using ACC.MVC;
using ACC.Safety;
using AutoMapper;
using DG.Application.Member;
using DG.Application.Member.Dtos;
using DG.Core.Entities;
using DG.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ACC.Extensions;

namespace DG.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IBasicEntityService _entityService;
        public HomeController(IBasicEntityService basicEntityService)
        {
            _entityService = basicEntityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
