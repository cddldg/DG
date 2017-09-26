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
    public class Member: BaseEntiy
    {
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
        public string Name { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 会员头像地址
        /// </summary>
        public string HeadImg { get; set; }
    }
}
