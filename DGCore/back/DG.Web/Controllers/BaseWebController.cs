using ACC.MVC;
using ACC.Extensions;
using DG.Application.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DG.Core.Constant;
using ACC.Application;

namespace DG.Web.Controllers
{
    public class BaseWebController : BaseController
    {   
        public IMemoryCache _cache = null;
        public IMemoryCache Cache
        {
            get
            {
                if (this._cache == null)
                {
                    IMemoryCache memoryCache = HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;
                    this._cache = memoryCache;
                }

                return this._cache;
            }
        }

        public  UsersOutput Users
        {
            get
            {
                var result = HttpContext.Session.Get<Result<UsersOutput>>(ConstNames.Users);
                if (result!=null&&result.IsError==YesNo.No&&result.Data!=null)
                {
                    return result.Data;
                }
                return null;
            }
        }
        
    }
}
