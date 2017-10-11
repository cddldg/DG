using ACC.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using DG.EntityFramework;
using ACC.AutoMapper;
using System.Linq;
using ACC.Convert;
using Microsoft.Extensions.Logging;

namespace DG.Application
{
    public class BasicEntityService : IBasicEntityService
    {
        #region Ctor
        protected ILogger log;
        protected readonly DGDbContext _dbContext;
        public BasicEntityService(DGDbContext db, ILoggerFactory loggerFactory)
        {
            log = loggerFactory.CreateLogger<BasicEntityService>();
            _dbContext = db;
        } 
        #endregion

        #region 添加数据

        public Result<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity,new()
        {
            var result = new Result<TEntity>();
            try
            {
                var DbSet = _dbContext.Set<TEntity>();
                var resultEntity = DbSet.Add(entity);
                _dbContext.SaveChanges();
                result.Data = resultEntity.Entity;
            }
            catch (Exception ex)
            {
                result.IsError = YesNo.Yes;
                log.LogError(ex.Message,ex);
            }

            return result;
        }

        public Result<TEntity> AddDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity, new()
        {
            var entity = dto.MapTo<TDto, TEntity>();
            return Add<TEntity>(entity);
        }

        #endregion

        #region 查询数据

        public TEntity GetByKey<TEntity>(object key) where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            return DbSet.Find(key);
        }

        public List<TEntity> GetList<TEntity>() where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            return DbSet.ToList();
        }

        public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            return DbSet.Where(predicate).ToList();
        } 

        #endregion
        
        #region 删除数据

        public int Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            DbSet.Remove(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            var entitys = DbSet.Where(predicate);
            var count = 0;
            foreach (var entity in entitys)
            {
                count += Delete<TEntity>(entity);
            }
            return count;
        }
        public int DeleteByKey<TEntity>(object key) where TEntity : BaseEntity
        {
            TEntity entity = null;
            entity.ID = key.Trylong();
            return Delete<TEntity>(entity);
        }
        public int SoftDelete<TEntity>(object key) where TEntity : BaseEntity
        {

            return 0;
        }
        public int SoftDelete<TEntity>(object key, object deleteUserId) where TEntity : BaseEntity
        {
            return 0;
        } 

        #endregion

        #region 修改数据

        public int Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var DbSet = _dbContext.Set<TEntity>();
            DbSet.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int UpdateDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity
        {
            var entity = dto.MapTo<TDto, TEntity>();
            return Update<TEntity>(entity);
        }

        #endregion

        #region Dispose DbContext
        /// <summary>
        /// Dispose DbContext
        /// </summary>
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        } 
        #endregion
    }
}
