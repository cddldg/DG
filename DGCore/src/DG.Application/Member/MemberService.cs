using DG.Application.Member.Dtos;
using DG.Core.Entities;
using DG.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using ACC;
using ACC.AutoMapper;
using ACC.Common;
using ACC.Safety;
using Microsoft.EntityFrameworkCore;

namespace DG.Application.Member
{
    public class MemberService : IMemberService
    {
        private readonly DGDbContext _dbContext;
        private readonly DbSet<MemberEntity> _dbSet;
        public MemberService(DGDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<MemberEntity>();
        }

        public void Dispose()
        {
            //if (_dbContext != null)
            //{
            //    _dbContext.Dispose();
            //}
        }
    }
}
