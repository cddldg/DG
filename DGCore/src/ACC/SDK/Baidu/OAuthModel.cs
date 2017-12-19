using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.SDK.Baidu
{
    /// <summary>
    /// 获取 Access Token
    /// </summary>
    public class OAuthModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Access_token { get; set; }//": "1.a6b7dbd428f731035f771b8d********.86400.1292922000-2346678-124328",

        /// <summary>
        /// 
        /// </summary>
        public int Expires_in { get; set; }//": 86400,

        /// <summary>
        /// 
        /// </summary>
        public string Refresh_token { get; set; }//": "2.385d55f8615fdfd9edb7c4b********.604800.1293440400-2346678-124328",

        /// <summary>
        /// 
        /// </summary>
        public string Scope { get; set; }//": "public",

        /// <summary>
        /// 
        /// </summary>
        public string Session_key { get; set; }//": "ANXxSNjwQDugf8615Onqeik********CdlLxn",

        /// <summary>
        /// 
        /// </summary>
        public string Session_secret { get; set; }//": "248APxvxjCZ0VEC********aK4oZExMB",
    }
}
