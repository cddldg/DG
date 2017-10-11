using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Extensions
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
        public static string ToyyyyMMddHHmm(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm");
        }
        public static string ToyyyyMMddHHmmss(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }


        #region 时间转文本

        public static string TimeIntervalCN(this DateTime src)
        {
            return ToRead(src as DateTime?);
        }
        public static string ToRead(this DateTime? src)
        {
            string result = null;
            if (src.HasValue)
            {
                result = DateTimeToStr2(src.Value);
            }
            return result;
        }

        private static string DateTimeToStr1(DateTime src)
        {
            string result = null;
            TimeSpan timeSpan = DateTime.Now - src;
            if (((int)timeSpan.TotalDays) > 365) //大于一年的
            {
                int years = (int)timeSpan.TotalDays / 365;
                //if (timeSpan.TotalDays % 365 > 0) years++;
                result = $"{years}年之前";
            }
            else if (((int)timeSpan.TotalDays) > 30) //大于一个月的
            {
                int months = (int)timeSpan.TotalDays / 30;
                //if (timeSpan.TotalDays % 30 > 0) months++;
                result = $"{months}个月前";
            }
            else if (((int)timeSpan.TotalDays) > 7) //大于一周的
            {
                int weeks = (int)timeSpan.TotalDays / 7;
                //if (timeSpan.TotalDays % 7 > 0) weeks++;
                result = $"{weeks}周前";
            }
            else if (((int)timeSpan.TotalDays) > 0) //大于 0 天的
            {
                result = $"{(int)timeSpan.TotalDays}天前";
            }
            else if (((int)timeSpan.TotalHours) > 0) //一小时以上的
            {
                result = $"{(int)timeSpan.TotalHours}小时";
            }
            else if (((int)timeSpan.TotalMinutes) > 0) //一分钟以上的
            {
                result = $"{(int)timeSpan.TotalMinutes}分钟前";
            }
            else if (((int)timeSpan.TotalSeconds) >= 0 && ((int)timeSpan.TotalSeconds) <= 60) //一分钟内
            {
                result = "刚刚";
            }
            else
            {
                result = src.ToyyyyMMddHHmmss();
            }
            return result;
        }

        private static string DateTimeToStr2(DateTime src)
        {
            string result = null;

            long currentSecond = (long)(DateTime.Now - src).TotalSeconds;

            long minSecond = 60;                //60s = 1min
            long hourSecond = minSecond * 60;   //60*60s = 1 hour
            long daySecond = hourSecond * 24;   //60*60*24s = 1 day
            long weekSecond = daySecond * 7;    //60*60*24*7s = 1 week
            long monthSecond = daySecond * 30;  //60*60*24*30s = 1 month
            long yearSecond = daySecond * 365;  //60*60*24*365s = 1 year

            if (currentSecond >= yearSecond)
            {
                int year = (int)(currentSecond / yearSecond);
                result = $"{year}年前"; 
            }
            else if (currentSecond < yearSecond && currentSecond >= monthSecond)
            {
                int month = (int)(currentSecond / monthSecond);
                result = $"{month}个月前";
            }
            else if (currentSecond < monthSecond && currentSecond >= weekSecond)
            {
                int week = (int)(currentSecond / weekSecond);
                result = $"{week}周前";
            }
            else if (currentSecond < weekSecond && currentSecond >= daySecond)
            {
                int day = (int)(currentSecond / daySecond);
                result = $"{day}天前";
            }
            else if (currentSecond < daySecond && currentSecond >= hourSecond)
            {
                int hour = (int)(currentSecond / hourSecond);
                result = $"{hour}小时前";
            }
            else if (currentSecond < hourSecond && currentSecond >= minSecond)
            {
                int min = (int)(currentSecond / minSecond);
                result = $"{min}分钟前";
            }
            else if (currentSecond < minSecond && currentSecond >= 0)
            {
                result = "刚刚";
            }
            else
            {
                result = src.ToyyyyMMddHHmmss();
            }
            return result;
        }

        #endregion
    }
}
