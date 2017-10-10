
using ACC.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DG.Core.Entities
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    [Table("Menu")]
    public class MenuEntity : BaseEntity
    {
        /// <summary>
        /// 父ID
        /// </summary>
        public long PID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图标（class name）
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
