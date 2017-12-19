using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.SDK.Baidu
{
    /// <summary>
    /// 错误
    /// </summary>
    public class ErrModel
    {
        /// <summary>
        /// 错误码	含义
        /// 500	不支持输入
        /// 501	输入参数不正确
        /// 502	token验证失败
        /// 503	合成后端错误
        /// </summary>
        public string Err_no { get; set; }//":500,

        /// <summary>
        /// 
        /// </summary>
        public string Err_msg { get; set; }//":"notsupport.",

        /// <summary>
        /// 
        /// </summary>
        public string Sn { get; set; }//":"abcdefgh",

        /// <summary>
        /// 
        /// </summary>
        public int Idx { get; set; }//":1}

        /// <summary>
        /// 语言数据
        /// </summary>
        public byte[] Data { get; set; }
    }
}
