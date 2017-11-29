using ACC.String;
using System;
using System.Collections.Generic;
using System.Text;


namespace ACC.Common
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserHelper
    {
        /// <summary>
        /// 用户密钥
        /// </summary>
        /// <returns></returns>
        public static string GenUserSecretkey()
        {
            string no = CreateNo();
            string secretkey = no.GetMd5Hash().Substring(8, 16).ToLower();
            return secretkey;
        }

        /// <summary>
        /// 随机编号
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;
            return code;
        }
    }
}
