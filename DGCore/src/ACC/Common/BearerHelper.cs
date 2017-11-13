using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Common
{
    public static class BearerHelper
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
    /// <summary>
    /// jwt输出
    /// </summary>
    public class JWTOutput
    {
        /// <summary>
        /// Access_Token
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int Expires_In { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Token_Type { get; set; } = "Bearer";
    }

}
