using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Controllers.WebApi
{
    [Produces("application/json")]
    //[Route("api/[controller]/[action]")]
    [Area("api")]
    public class ApiBaseController: Controller
    {
    }
}
