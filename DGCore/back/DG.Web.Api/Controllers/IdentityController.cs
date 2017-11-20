using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DG.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var username = User.Claims.First(x => x.Type == "email").Value;
            return Ok(username);
            //return new JsonResult(from c in User.Claims select new { c.Type, c.Value});
        }

    }
}