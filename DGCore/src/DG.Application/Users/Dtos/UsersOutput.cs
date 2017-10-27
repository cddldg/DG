using DG.Core.Entities;
using DG.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DG.Application.Users.Dtos
{
    /// <summary>
    /// 用户输出类
    /// </summary>
    public class UsersOutput: BaseDto
    {
        /// <summary>
        /// 会员用户名
        /// </summary>
        [Required]
        [MaxLength(UsersEntity.UserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(UsersEntity.PasswordLength)]
        public string Password { get; set; }

        [Required]
        public string Secretkey { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(UsersEntity.MobileLength)]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [MaxLength(UsersEntity.EmailLength)]
        public string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? PreviousLogOnTime { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime? LastLogOnTime { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LogOnCount { get; set; }
    }
}
