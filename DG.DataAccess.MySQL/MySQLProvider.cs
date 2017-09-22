using DG.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.DataAccess.MySQL
{
    public class MySQLProvider : IDataAccessProvider
    {
        public long Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long key)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> GetPage<T>(int pageNo = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public T GetSingle<T>(long key)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
