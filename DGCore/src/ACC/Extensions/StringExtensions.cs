using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Extensions
{
    /// <summary>
    /// String扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// obj ToString
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        public static string ObjToString(this object objStr)
        {
            return objStr == null ? string.Empty : (objStr.ToString().Trim() == "null" ? string.Empty : objStr.ToString().Trim());
        }
    }
}
