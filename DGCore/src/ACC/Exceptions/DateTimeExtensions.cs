using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Exceptions
{
    /// <summary>
    /// 时间处理扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime time)
        {
            DateTime startTime = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
            return (long)(time - startTime).TotalMilliseconds;
        }
        
        public static string ToyyyyMMdd(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }
        public static string ToyyyyMMddHH(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH");
        }
        public static string ToyyyyMMddHHss(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:ss");
        }
        public static string ToyyyyMMddHHssmm(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:ss:mm");
        }
        /// <summary>
        /// 获取中文间隔时间差
        /// </summary>
        /// <param name="time"></param>
        /// <param name="nowTime"></param>
        /// <returns></returns>
        public static string TimeIntervalCN(this DateTime time, DateTime? nowTime)
        {
            var now = nowTime ?? DateTime.Now;
            var span = now.Subtract(time);
            var day = 60 * 24;//天
            var hour = 60;
            if (span.Minutes >= day * 4)
            {
                return string.Format("{0}年{1}月{2}日", time.Year, time.Month, time.Day);
            }
            else if (span.Minutes >= day * 3 && span.Minutes < day * 4)
            {
                return string.Format("{0}天前", span.Days);
            }
            else if (span.Minutes >= day * 2 && span.Minutes < day * 3)
            {
                return string.Format("{0}天前", span.Days);
            }
            else if (span.Minutes > day && span.Minutes < day * 2)
            {
                return string.Format("{0}天前", span.Days);
            }
            else if (span.Minutes < day && span.Minutes >= hour)
            {
                return string.Format("{0}小时前", span.Minutes % 60);
            }
            else if (span.Minutes < hour && span.Minutes >= 1)
            {
                return string.Format("{0}分钟前", span.Minutes);
            }
            else
            {
                return "刚刚";
            }
        }
    }
}
