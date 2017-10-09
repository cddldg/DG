using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using DG.EntityFramework;
using ACC.AutoMapper;
using AutoMapper;

namespace DG.Application
{
    public abstract  class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntiy
    {
        protected readonly DGDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseService(DGDbContext _db)
        {
            _dbContext = _db;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity AddForDto<TInDto>(TInDto inDto)
        {
            var entity = inDto.MapTo<TInDto, TEntity>();
            var model=_dbSet.Add(entity).Entity;
            _dbContext.SaveChanges();
            return model;
        }

        public long Delete(TEntity entity)
        {
             entity = _dbSet.Remove(entity).Entity;
            
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public long DeleteByKey(object key)
        {
            TEntity entity = _dbSet.Find(key);


            return Delete(entity);
        }

        public void Dispose()
        {
            if(_dbContext!=null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
