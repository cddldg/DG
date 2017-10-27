using ACC.Application;
using DG.Core.Entities.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DG.Core.Entities
{
    /// <summary>
    /// 用户基础表
    /// </summary>
    [Table("Users")]
    public class UsersEntity : BaseEntity
    {
        public const int UserNameLength = 256;
        public const int PasswordLength =500;
        public const int MobileLength = 100;
        public const int EmailLength = 200;

        /// <summary>
        /// 会员用户名
        /// </summary>
        [Required]
        [MaxLength(UserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(PasswordLength)]
        public string Password { get; set; }

        [Required]
        public string Secretkey { get; set; }
        
        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(MobileLength)]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [MaxLength(EmailLength)]
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
    //public void Maps(EntityTypeBuilder<UsersEntity> builder)
    //{
    //    builder.HasIndex(x => x.Email).IsUnique();
    //    builder.HasIndex(x => x.Mobile).IsUnique();
    //}
}
