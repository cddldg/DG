using ACC.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Safety
{
    public static class PasswordHelper
    {
        /// <summary>
        /// 生成密码入口
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <param name="secretKey">key</param>
        /// <returns></returns>
        public static string Encrypt(string password, string secretKey)
        {
            string ret = EncryptMD5Password(password.GetMd5Hash(), secretKey);
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="md5Password">经过md5加密的密码</param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static string EncryptMD5Password(string md5Password, string secretKey)
        {
            secretKey = secretKey.GetMd5Hash().Substring(0, 16);
            string encryptedPassword = EncryptHelper.AESEncrypt(md5Password.ToLower(), secretKey).ToLower();
            string ret = encryptedPassword.GetMd5Hash().ToLower();
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pwdText">明文密码</param>
        public static void EnsurePasswordLegal(string pwdText)
        {
            if (pwdText == null || pwdText.Length < 6 || pwdText.Length > 15)
                throw new Exception("密码必须是6-15位");
        }
    }
}
