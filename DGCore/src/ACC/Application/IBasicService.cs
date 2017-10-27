using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ACC.Application
{
    /// <summary>
    /// 实体基础操作业务服务(单表)
    /// </summary>
    /// <typeparam name="TEntiy">实体</typeparam>
    public interface IBasicEntityService: IAppService
    {
        #region 增
        Result<TDto> Add<TEntity, TDto>(TEntity entity) where TEntity : BaseEntity,new() where TDto : new();
        Result<TDto> AddDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity, new() where TDto : new();
        #endregion

        #region 删
        ResultBasic<int> Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;
        ResultBasic<int> Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;
        ResultBasic<int> DeleteByKey<TEntity>(object key) where TEntity : BaseEntity,new();
        ResultBasic<int> SoftDelete<TEntity>(object key) where TEntity : BaseEntity, new();
        ResultBasic<int> SoftDelete<TEntity>(object key, object deleteUserId) where TEntity : BaseEntity, new();
        #endregion

        #region 改
        ResultBasic<int> Update<TEntity>(TEntity entity) where TEntity : BaseEntity;
        ResultBasic<int> UpdateDto<TEntity, TDto>(TDto dto) where TEntity : BaseEntity;
        #endregion

        #region 查
        Result<TDto> GetByKey<TEntity, TDto>(object key) where TEntity : BaseEntity, new() where TDto:new();
        Result<List<TDto>> GetList<TEntity, TDto>() where TEntity : BaseEntity, new();
        Result<List<TDto>> GetList<TEntity, TDto>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity, new();
        Result<List<TDto>> GetPager<TEntity, TDto>(int pageIndex,int pageSize,string orderby) where TEntity : BaseEntity, new();
        #endregion
    }
}
