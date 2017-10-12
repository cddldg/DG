using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.Common
{
    public static class CNMobile
    {
        /*
         *移动号段：
         *134,135,136,137,138,139,147,148,150,151,152,157,158,159,172,178,182,183,184,187,188,198
         *联通号段：
         *130,131,132,145,146,155,156,166,171,175,176,185,186
         *电信号段：
         *133,149,153,173,174,177,180,181,189,199
         *虚拟运营商:
         *170
         */
        private static string[] telStarts = "134,135,136,137,138,139,147,148,150,151,152,157,158,159,172,178,182,183,184,187,188,198,130,131,132,145,146,155,156,166,171,175,176,185,186,133,149,153,173,174,177,180,181,189,199,170".Split(',');

        /// <summary>
        /// 随机生成电话号码
        /// </summary>
        /// <returns></returns>
        public static string GetRandomMobNO()
        {
            Random rnd = new Random((int)DateTime.Now.ToFileTimeUtc());
            int n = rnd.Next(10, 1000);
            int index = rnd.Next(0, telStarts.Length - 1);
            string first = telStarts[index];
            string second = (rnd.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (rnd.Next(1, 9100) + 10000).ToString().Substring(1);
            return (first + second + thrid).Trim();
        }
    }
}
