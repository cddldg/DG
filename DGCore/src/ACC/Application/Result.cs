using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Application
{

    /// <summary>
    /// 通用返回
    /// </summary>
    public  class Result
    {
        /// <summary>
        /// 是否有错误
        /// </summary>
        public YesNo IsError { get; set; } = YesNo.No;

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }


        /// <summary>
        /// 附加信息
        /// </summary>
        public string Additional { get; set; }


        public int Count { get; set; }
        /// <summary>
        /// 系统时间
        /// </summary>
        public DateTime ServiceTime { get; set; }= DateTime.Now;

    }

    /// <summary>
    /// 通用返回(带附加数据)
    /// Data为基础类型数据 不能被实例化的，比如 string  int 等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultBasic<T> : Result
    {
        public T Data { get; set; }
    }

    /// <summary>
    /// 通用返回(带附加数据)
    /// Data对象要能被实例化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result where T : new()
    {
        private T _data = new T();

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
