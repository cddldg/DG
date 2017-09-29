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

namespace DG.Application.Member
{
    public class MemberService :BaseService<MemberEntity>,IMemberService
    {
        public MemberService(DGDbContext _dbContext):base(_dbContext)
        {

        }

        public MemberOutput Add(AddMemberInput input)
        {
            #region 处理密码
            var key = UserHelper.GenUserSecretkey();
            var pwd = PasswordHelper.Encrypt(input.Password, key);
            input.Password = pwd;
            input.Secretkey = key; 
            #endregion

            var entity=AddForDto(input);
            var model = entity.MapTo<MemberEntity, MemberOutput>();
            return model;
        }
    }
}
