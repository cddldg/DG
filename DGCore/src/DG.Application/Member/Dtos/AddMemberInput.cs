using ACC.AutoMapper;
using DG.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DG.Application.Member.Dtos
{
    public class AddMemberInput:BaseDto
    {
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
        [MaxLength(MemberEntity.MaxNameLength)]
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
        [MaxLength(MemberEntity.MaxDescriptionLength)]
        public string Description { get; set; }
    }

}
