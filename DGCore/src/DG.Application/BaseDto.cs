
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ACC.Convert;
using Newtonsoft.Json;
using ACC.Extensions;

namespace DG.Application
{
    [Serializable]
    public class BaseDto
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        [Key]
        [JsonConverter(typeof(LongConverter))]
        public long ID { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [JsonConverter(typeof(LongConverter))]
        public long CreateUserID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        [JsonConverter(typeof(LongConverter))]
        public long UpdateUserID { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// toJsonString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJson();
        }

        /// <summary>
        /// CreateTime距离现在时间
        /// </summary>
        public string IntervalTime
        {
            get => CreateTime.TimeIntervalCN();
            set => IntervalTime = value;
        }
    }
}
