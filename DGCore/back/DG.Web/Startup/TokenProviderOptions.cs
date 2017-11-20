using DG.Application.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DG.Web
{
    public class TokenProviderOptions
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public string Path { get; set; } = "/api/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }
        /// <summary>
        /// 间隔过期时间
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromSeconds(10);

        public SigningCredentials SigningCredentials { get; set; }

    }
}
