using ACC.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DG.Core.Entities
{
    /// <summary>
    /// 会员实体
    /// </summary>
    [Table("Member")]
    public class MemberEntity: BaseEntity
    {
        public const int MaxNameLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        [Required]
        public string Secretkey { get; set; }
        /// <summary>
        /// 会员用户名
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }


        /// <summary>
        /// 会员真实姓名
        /// </summary>
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 会员头像地址
        /// </summary>
        public string HeadImg { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
