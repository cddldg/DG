using DG.Core.Entities;
using DG.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Application
{
    public interface IMenuService: IDGDbContextBase<Menu>
    {
        bool CheangeUrl(long id,string url);
    }
}
