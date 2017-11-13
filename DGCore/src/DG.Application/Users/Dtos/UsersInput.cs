using DG.Core.Entities;
using DG.Core.Entities.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DG.Application.Users.Dtos
{
    /// <summary>
    /// 用户输入类
    /// </summary>
    public class UsersInput: BaseDto
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
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

    }
}
