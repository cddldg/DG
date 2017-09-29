using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Controllers.Api
{
    [Produces("application/json")]
    [Area("api")]
    public abstract class BaseApiController:Controller
    {
    }
}
