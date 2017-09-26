using DG.Core.Entities;
using DG.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DG.Application
{
    public class MenuService : BaseService<Menu>,IMenuService
    {
        public MenuService(MySqlDbContext _db, ILoggerFactory loggerFactory):base(_db,loggerFactory)
        {
            
        }
        public bool CheangeUrl(long id, string url)
        {
            var model =GetSingle(id);
            model.Url = url;
            try
            {
                string ps = model.ToString();
            }
            catch (Exception ex)
            {

                
            }
            _logger.LogInformation(url);
            return Update(model);
        }

    }
}
