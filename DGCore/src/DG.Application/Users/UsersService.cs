using System;
using System.Collections.Generic;
using System.Text;
using DG.Application.Users.Dtos;
using DG.EntityFramework;
using DG.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ACC.Safety;
using ACC.Application;
using ACC.AutoMapper;
using static DG.Core.Constant;
using Microsoft.Extensions.Logging;

namespace DG.Application.Users
{
    public class UsersService : IUsersService
    {
        protected ILogger _log;
        private readonly DGDbContext _dbContext;
        private readonly DbSet<UsersEntity> _dbSet;
        public UsersService(DGDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<UsersEntity>();
            _log = loggerFactory.CreateLogger<UsersService>();
        }

        //public bool CheckUsers(string userName, string password)
        //{
        //    bool isOk = false;
        //    var entity=_dbSet.FirstOrDefault(p=>p.UserName==userName);
        //    if (entity != null)
        //    {
        //        var key =PasswordHelper.Encrypt(password, entity.Secretkey);
        //        if(key==entity.Password)
        //        {
        //            isOk= true;
        //        }
        //    }
        //    return isOk;
        //}
        public Result<UsersOutput> CheckUsers(string userName, string password)
        {   
            var result = new Result<UsersOutput>() { IsError=YesNo.Yes};
            try
            {   
                var resultEntity = _dbSet.FirstOrDefault(p => p.UserName == userName);
                if (resultEntity != null)
                {
                    var key = PasswordHelper.Encrypt(password, resultEntity.Secretkey);
                    if (key == resultEntity.Password)
                    {
                        result.IsError = YesNo.No;
                        result.Data = resultEntity.MapTo<UsersEntity, UsersOutput>();
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsError = YesNo.Yes;
                result.ErrorMessage = ex.Message;
                result.ErrorCode = ErrorCode.Exception;
                _log.LogError(ex.Message, ex);
            }
            return result;
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
