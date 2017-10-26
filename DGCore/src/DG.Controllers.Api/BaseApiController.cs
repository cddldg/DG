using ACC.MVC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Controllers.Api
{
    [Produces("application/json")]
    [Area("api")]
    [Authorize]
    public abstract class BaseApiController: BaseController
    {
    }
}
