using ACC.Application;
using DG.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Application.Users
{
    public interface  IUsersService: IAppService
    {
        /// <summary>
        /// 验证用户合法性
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Result<UsersOutput> CheckUsers(string userName,string password);
    }
}
