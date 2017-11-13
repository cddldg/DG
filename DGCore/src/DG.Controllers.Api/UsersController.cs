using ACC.Application;
using ACC.Common;
using ACC.Safety;
using DG.Application.Users.Dtos;
using DG.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DG.Controllers.Api
{
    public class UsersController : BaseApiController
    {
        private IBasicEntityService _entityService;
        public UsersController(IBasicEntityService basicEntityService)
        {
            _entityService = basicEntityService;
        }


        [HttpPost]
        public Result Add(UsersInput input)
        {
            #region 处理密码 随机生产信息
            var key = UserHelper.GenUserSecretkey();
            var pwd = PasswordHelper.Encrypt(input.Password, key);
            input.Password = pwd;
            input.Secretkey = key;
            input.UserName = CNName.GetRandomString();
            input.Gender = (DateTime.Now.Second % 2 == 0) ? Core.Entities.Enum.Gender.女 : ((DateTime.Now.Second % 3 == 0)?Core.Entities.Enum.Gender.男: Core.Entities.Enum.Gender.保密);
            input.Mobile = CNMobile.GetRandomMobNO();
            input.Birthday = CNName.GetRandomDateTime();
            #endregion
            var model = _entityService.AddDto<UsersEntity, UsersInput>(input);
            return model;
        }

        public Result GetAll()
        {
            var model = _entityService.GetList<UsersEntity,UsersOutput>();
            return model;
        }
        public Result GetPager(int pageIndex = 1, int pageSize = 10, string orderby = "ID desc,UserName asc")
        {
            var dict = new Dictionary<string, string>();

            HttpContext.User.Claims.ToList().ForEach(item => dict.Add(item.Type, item.Value));

            var p = User;
            
            var model = _entityService.GetPager<UsersEntity,UsersOutput>(pageIndex, pageSize, orderby);
            return model;
        }

        public Result Del(long id)
        {
            return _entityService.DeleteByKey<UsersEntity>(id);
        }
        public Result SoftDel(long id)
        {
            return _entityService.SoftDelete<UsersEntity>(id);
        }
    }
}
