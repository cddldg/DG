using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ACC.Exceptions;

namespace ACC.Extensions
{
    /// <summary>
    /// Linq lambda的扩展
    /// </summary>
    public static class LinqExpressions
    {
        #region 分页查询

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 分页排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count">数据总行数</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy">orderBy字段 Lambda表达式</param>
        /// <param name="asc">true asc;false desc</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, out int count, int pageIndex, int pageSize, Expression<Func<T, object>> orderBy, bool asc = true)
        {
            count = query.Count();
            return asc ? query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize) : query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }


        /// <summary>
        /// 分页排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count">数据总行数</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy">排序字符串，如："id desc,name ase"</param>
        /// <param name="asc">true asc;false desc</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, out int count, int pageIndex, int pageSize, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                throw new ACCException("参数'orderBy'不能为空.");
            }
            count = query.Count();
            return query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> PageBy<T>(this IEnumerable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 分页排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count">数据总行数</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy">orderBy字段 Lambda表达式</param>
        /// <param name="asc">true asc;false desc</param>
        /// <returns></returns>
        public static IEnumerable<T> PageBy<T>(this IEnumerable<T> query, out int count, int pageIndex, int pageSize, Func<T, object> orderBy, bool asc = true)
        {
            count = query.Count();
            return asc ? query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize) : query.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        #endregion

        #region WhereIf
        /// <summary>
        /// 扩展条件查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">where条件（lambda表达式）</param>
        /// <param name="condition">true=添加条件false=不添加条件</param>
        /// <returns>创建时间：2015-01-04</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        #endregion

        #region DistinctBy
        /// <summary>
        /// List去重
        /// DistinctBy=》GroupBy
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static IEnumerable<t> DistinctBy<t>(this IEnumerable<t> list, Func<t, object> propertySelector)
        {
            return list.GroupBy(propertySelector).Select(x => x.First());
        }
        #endregion

        #region OrderBy
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="ordering">排序字符串，如：OrderBy("id desc,name ase")</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string ordering, params object[] values)
        {
            if (query == null)
                throw new ACCException("query");
            return DynamicQueryableExtensions.OrderBy(query, ordering, values);
        }
        #endregion
    }
}
