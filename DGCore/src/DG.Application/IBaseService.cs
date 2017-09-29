using ACC.Application;
using DG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DG.Application
{
    public interface IBaseService<TEntity> :IBasicEntityService<TEntity> where TEntity : class
    {

    }
}
