using ACC.Application;
using DG.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DG.Core.Entities
{
    /// <summary>
    /// 日志
    /// </summary>
    [Table("Log")]
    public class LogEntity: BaseEntity
    {
        public string UserId { get; set; }
        
        public string RealName { get; set; }

        public LogType Type { get; set; }

        public string IP { get; set; }

        public ClientType ClientType { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 模块编号
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}
