using ACC.String;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Common
{
    public class UserHelper
    {
        public static string GenUserSecretkey()
        {
            string no = CreateNo();
            string secretkey = no.GetMd5Hash().Substring(8, 16).ToLower();
            return secretkey;
        }

        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;
            return code;
        }
    }
}
