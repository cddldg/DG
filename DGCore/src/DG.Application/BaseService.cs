using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using DG.EntityFramework;

namespace DG.Application
{
    public  class BaseService<T> : IDGDbContextBase<T> where T : BaseEntiy
    {
        protected readonly MySqlDbContext db;
        protected readonly DbSet<T> set;
        protected readonly ILogger _logger; 
        
        public BaseService(MySqlDbContext _db, ILoggerFactory loggerFactory)
        {
            db = _db;
            set = db.Set<T>();
            _logger=loggerFactory.CreateLogger<BaseService<T>>();
        }
        public void Add(T entity)
        {
            set.Add(entity);
            db.SaveChanges();
        }

        public long AddOutID(T entity)
        {
            var model = set.Add(entity);
            db.SaveChanges();
            return model == null ? 0 : model.Entity.ID;
        }

        public bool Delete(long id)
        {
            var soure = set.Single(p=>p.ID==id);
            var model = set.Remove(soure);
            db.SaveChanges();
            return model != null;
        }

        public IList<T> GetAll()
        {
            return set.ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> where)
        {
            return set.Where(where).ToList();
        }

        public T GetSingle(long id)
        {
            return set.Single(p=>p.ID==id);
        }

        public bool Update(T entity)
        {
            var model = set.Update(entity);
            db.SaveChanges();
            return model != null;
        } 
    }
}
