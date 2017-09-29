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
    
    public class CategoryController: ApiBaseController
    {
        private MyContext _myContext;
        public CategoryController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet]
        public int ShowAndOne(int id)
        {
            return id + 1;
        }
        [HttpGet]
        public List<Category> GetCategoyPage(int pageNo,int pageSize)
        {
            var model = _myContext.Category.PageBy(out int c, pageNo, pageSize, p => p.SysNo).ToList();
            var ps = c;
            return model;
        }   
    }
}
