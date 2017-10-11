using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ACC.Application
{
    /// <summary>
    /// 实体基础操作业务服务
    /// </summary>
    /// <typeparam name="TEntiy">实体</typeparam>
    public interface IBasicEntityService: IAppService
    {
        #region 增
        Result<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseEntity,new();
        Result<TEntity> AddDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity, new();
        #endregion

        #region 删
        int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;
        int Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int DeleteByKey<TEntity>(object key) where TEntity : BaseEntity;
        int SoftDelete<TEntity>(object key) where TEntity : BaseEntity;
        int SoftDelete<TEntity>(object key, object deleteUserId) where TEntity : BaseEntity;
        #endregion

        #region 改
        int Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int UpdateDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity;
        #endregion
        
        #region 查
        TEntity GetByKey<TEntity>(object key) where TEntity : BaseEntity;
        List<TEntity> GetList<TEntity>() where TEntity : BaseEntity;
        List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity; 
        #endregion
    }
}
