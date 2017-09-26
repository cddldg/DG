using DG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DG.EntityFramework
{
    public interface IDGDbContextBase<T> where T : BaseEntiy
    {
        void Add(T entity);
        /// <summary>
        /// 添加并返回主键值0为失败
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        long AddOutID(T entity);
        bool Update(T entity);
        bool Delete(long id);
        T GetSingle(long id);
        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T,bool>> where);
    }
}
