using ACC.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACC.SDK.Baidu.Api
{
    /// <summary>
    /// 百度语音
    /// </summary>
    public static class Speech
    {
        private static string tokenUrl = "https://openapi.baidu.com/oauth/2.0/token?grant_type=client_credentials&client_id={0}&client_secret={1}";
        private static string text2AudioUrl = "http://tsn.baidu.com/text2audio";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="secretKey"></param>
        public static OAuthModel Client(string apiKey, string secretKey)
        {
            string getTokenUrl = string.Format(tokenUrl,apiKey,secretKey);
            return HttpClientHelper.HttpGetJson<OAuthModel>(getTokenUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">
        /// 参数	可需	描述
        /// tex 必填  合成的文本，使用UTF-8编码。小于512个中文字或者英文数字。（文本在百度服务器内转换为GBK后，长度必须小于1024字节）
        /// tok 必填  开放平台获取到的开发者access_token（见上面的“鉴权认证机制”段落）
        /// cuid 必填  用户唯一标识，用来区分用户，计算UV值。建议填写能区分用户的机器 MAC 地址或 IMEI 码，长度为60字符以内
        /// ctp 必填 客户端类型选择，web端填写固定值1
        /// lan 必填 固定值zh。语言选择,目前只有中英文混合模式，填写固定值zh
        /// spd 选填 语速，取值0-9，默认为5中语速
        /// pit 选填 音调，取值0-9，默认为5中语调
        /// vol 选填 音量，取值0-15，默认为5中音量
        /// per 选填 发音人选择, 0为普通女声，1为普通男生，3为情感合成-度逍遥，4为情感合成-度丫丫，默认为普通女声
        /// </param>
        public static string Text2Audio(Dictionary<string, string> options)
        {
            var getUrl = $"{text2AudioUrl}?";
            if (options != null)
            {
                foreach (KeyValuePair<string, string> current in options)
                {
                    getUrl +=$"&{current.Key}={current.Value}";
                }
            }

            //var result = HttpClientHelper.HttpGetData(getUrl);
            //File.WriteAllBytes("baidu.mp3", result.Data); 
            return getUrl;
        }

        
    }
}
