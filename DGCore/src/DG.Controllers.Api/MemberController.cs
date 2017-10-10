using ACC.Application;
using ACC.AutoMapper;
using ACC.Common;
using ACC.Safety;
using AutoMapper;
using DG.Application;
using DG.Application.Member;
using DG.Application.Member.Dtos;
using DG.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Controllers.Api
{
    public class MemberController:BaseApiController
    {
        private IBasicEntityService _entityService;
        public MemberController(IBasicEntityService basicEntityService) 
        {
            _entityService = basicEntityService;
        }
        
        
        [HttpPost]
        public MemberOutput Add(AddMemberInput input)
        {
            #region 处理密码
            var key = UserHelper.GenUserSecretkey();
            var pwd = PasswordHelper.Encrypt(input.Password, key);
            input.Password = pwd;
            input.Secretkey = key;
            #endregion
            var entity = _entityService.AddDto<MemberEntity, AddMemberInput>(input);
            var model = entity.MapTo<MemberEntity, MemberOutput>();
            return model;
        }

        public List<MemberOutput> GetAll()
        {
            var entitys=_entityService.GetList<MemberEntity>();
            var list =entitys.MapTo<MemberEntity, MemberOutput>();
            return list;
        }


        public int Del(long id)
        {
            return _entityService.DeleteByKey<MemberEntity>(id);
        }

    }
}
