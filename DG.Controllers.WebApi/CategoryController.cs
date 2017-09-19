using DG.Core.Entities;
using DG.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using DGCore.Linq;

namespace DG.Controllers.WebApi
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController: Controller
    {
        private MyContext _myContext;
        public CategoryController(MyContext myContext)
        {
            _myContext = myContext;
        }
        [HttpGet]
        public List<Category> Get(int pageNo,int pageSize)
        {
            var model = _myContext.Categories.PageBy(out int c, pageNo, pageSize, p => p.SysNo).ToList();
            var ps = c;
            return model;
        }


        
    }
}
