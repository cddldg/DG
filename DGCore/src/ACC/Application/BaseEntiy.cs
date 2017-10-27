using ACC.Convert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACC.Application
{
    /// <summary>
    /// 数据库实体的基类
    /// </summary>
    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        [Key]
        public long ID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long CreateUserID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public long UpdateUserID { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// toJsonString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJson();
        }
    }
}
