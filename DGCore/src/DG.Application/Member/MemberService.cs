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
    public class MemberService :IMemberService
    {
        private readonly DGDbContext _dbContext;
        private readonly DbSet<MemberEntity> _dbSet;
        public MemberService(DGDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<MemberEntity>();
        }

        public MemberOutput Add(AddMemberInput input)
        {
            #region 处理密码
            var key = UserHelper.GenUserSecretkey();
            var pwd = PasswordHelper.Encrypt(input.Password, key);
            input.Password = pwd;
            input.Secretkey = key;
            #endregion

            var entity = input.MapTo<AddMemberInput, MemberEntity>();
            var entityModel = _dbSet.Add(entity).Entity;
            var model = entityModel.MapTo<MemberEntity, MemberOutput>();
            _dbContext.SaveChanges();
            return model;
        }

        public long Delete(AddMemberInput input)
        {
            var entity = input.MapTo<AddMemberInput, MemberEntity>();
            var entityModel=_dbSet.Remove(entity).Entity;
            _dbContext.SaveChanges();
            return entityModel.ID;
        }

        public long DeleteByKey(long key)
        {
           var entity= _dbSet.Find(key);
            var entityModel = _dbSet.Remove(entity).Entity;
            _dbContext.SaveChanges();
            return entityModel.ID;
        }

        public void Dispose()
        {
            
        }
    }
}
