using ACC.Application;
using DG.Core.Entities.Enum;
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
        
        public long UsersID { get; set; }

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

        /// <summary>
        /// 会员等级
        /// </summary>
        public LevelType Level { get; set; }

        /// <summary>
        /// 用户基本信息
        /// </summary>
        public UsersEntity Users { get; set; }
    }
}
