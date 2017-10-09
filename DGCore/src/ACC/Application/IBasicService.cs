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
    public interface IBasicEntityService<TEntiy> where TEntiy : class
    {
        // T GetByKey(object key);
        // List<T> GetList<T>();
        // List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate);
        // int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate);
        // int Delete<TEntity>(TEntity entity);
        // int DeleteByKey<TEntity>(object key);
        // int SoftDelete<TEntity>(object key);
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <typeparam name="TEntity"></typeparam>
        // /// <param name="key"></param>
        // /// <param name="deleteUserId">执行删除操作的用户Id</param>
        // /// <returns></returns>
        // int SoftDelete<TEntity>(object key, object deleteUserId);
        // TEntity Add<TEntity>(TEntity entity);
        // /// <summary>
        // /// 传入一个 dto 对象，插入相应的数据
        // /// </summary>
        // /// <typeparam name="TEntity"></typeparam>
        // /// <typeparam name="TDto"></typeparam>
        // /// <param name="dto"></param>
        // /// <returns></returns>
        // TEntity AddFromDto<TEntity, TDto>(TDto dto) where TEntity : class;

        //int Update<TEntity>(TEntity entity);
        // /// <summary>
        // /// 传入一个 dto 对象，更新相应的数据
        // /// </summary>
        // /// <typeparam name="TEntity"></typeparam>
        // /// <typeparam name="TDto"></typeparam>
        // /// <param name="dto"></param>
        // /// <returns></returns>
        // int UpdateFromDto<TEntity, TDto>(TDto dto);

        TEntiy AddForDto<TInDto>(TInDto inDto);
    }
}
