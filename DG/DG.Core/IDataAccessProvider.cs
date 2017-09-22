using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Core
{
    public interface IDataAccessProvider
    {
        long Add<T>(T entity);
        bool Update<T>(T entity);
        bool Delete(long key);
        T GetSingle<T>(long key);
        List<T> GetAll<T>();
        List<T> GetPage<T>(int pageNo = 1, int pageSize = 10);
    }
}
