using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Convert
{
    /// <summary>
    /// 转换通用
    /// </summary>
    public static class ConvertHelper
    {
        #region 补足位数
        /// <summary>
        /// 指定字符串的固定长度，如果字符串小于固定长度，
        /// 则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero(string text, int limitedLength)
        {
            //补足0的字符串
            string temp = "";

            //补足0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //连接text
            temp += text;

            //返回补足0的字符串
            return temp;
        }
        #endregion
        
        #region int
        /// <summary>
        /// 转换int 失败了返回 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int TryInt(this object obj)
        {
            int.TryParse(obj.ToString(), out int ret);
            return ret;
        }

        /// <summary>
        /// 转换int 失败了返回 null int?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? TryNullInt(this object obj)
        {
            if (int.TryParse(obj.ToString(), out int cov))
            {
                return cov;
            }
            return null;
        }
        #endregion

        #region long
        /// <summary>
        /// 转换 long 失败了返回 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long Trylong(this object obj)
        {
            long.TryParse(obj.ToString(), out long ret);
            return ret;
        }

        /// <summary>
        /// 转换 long 失败了返回 null long?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? TryNulllong(this object obj)
        {
            if (long.TryParse(obj.ToString(), out long cov))
            {
                return cov;
            }
            return null;
        }
        #endregion

        #region double
        /// <summary>
        /// 转换 double 失败了返回 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double TryDouble(this object obj)
        {
            double.TryParse(obj.ToString(), out double ret);
            return ret;
        }

        /// <summary>
        /// 转换 double 失败了返回 null double?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? TryNullDouble(this object obj)
        {
            if (double.TryParse(obj.ToString(), out double cov))
            {
                return cov;
            }
            return null;
        }
        #endregion

        #region decimal
        /// <summary>
        /// decimal 失败了返回 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal TryDecimal(this object obj)
        {
            decimal.TryParse(obj.ToString(), out decimal ret);
            return ret;
        }

        /// <summary>
        /// 转换 decimal 失败了返回 null decimal?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? TryNullDecimal(this object obj)
        {
            if (decimal.TryParse(obj.ToString(), out decimal cov))
            {
                return cov;
            }
            return null;
        }
        #endregion

        #region float
        /// <summary>
        /// float 失败了返回 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float TryFloat(this object obj)
        {
            float.TryParse(obj.ToString(), out float ret);
            return ret;
        }

        /// <summary>
        /// 转换 float 失败了返回 null float?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? TryNullFloat(this object obj)
        {
            if (float.TryParse(obj.ToString(), out float cov))
            {
                return cov;
            }
            return null;
        }
        #endregion

        #region bit true/false
        /// <summary>
        /// 0 和 1返回 false 和 true
        /// 转换失败
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryBoolen(this object obj)
        {
            if (int.TryParse(obj.ToString(), out int ret))
            {
                return ret == 1;
            }
            else
            {
                throw new Exception("转换失败");
            }
        }

        /// <summary>
        /// false 和 true 返回 0 和 1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int TryBit(this object obj)
        {
            if (bool.TryParse(obj.ToString(), out bool ret))
            {
                return ret ? 1 : 0; ;
            }
            else
            {
                throw new Exception("转换失败");
            }
        }
        #endregion
    }
}
